using System.Net.Mime;
using System.Net.WebSockets;
using System.Text;
using Bliss.API.AppointmentManagement.Domain.Model.Commands;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Commands;
using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Queries;
using NRG3.Bliss.API.AppointmentManagement.Domain.Services;
using NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Resources;
using NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Transform;
using NRG3.Bliss.API.IAM.Application.Internal.OutboundServices;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Queries;
using NRG3.Bliss.API.ServiceManagement.Domain.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest;

/// <summary>
/// Controller for managing appointments
/// </summary>
/// <param name="appointmentCommandService">
/// The appointment command service
/// </param>
/// <param name="appointmentQueryService">
/// The appointment query service
/// </param>
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Appointments")]
public class AppointmentsController(
    IAppointmentCommandService appointmentCommandService,
    IAppointmentQueryService appointmentQueryService,
    Dictionary<string, List<WebSocket>> socketsDictionary,
    ICompanyQueryService companyQueryService
    ) : ControllerBase
{

    /// <summary>
    /// Get appointments by id
    /// </summary>
    /// <param name="appointmentId">
    /// The id of the appointment to get
    /// </param>
    /// <returns>
    /// The <see cref="AppointmentResource"/> resource with the given id
    /// </returns>
    [HttpGet("{appointmentId:int}")]
    [SwaggerOperation(
        Summary = "Get appointment by id",
        Description = "Get an appointment by the id it has",
        OperationId = "GetAppointmentById")]
    [SwaggerResponse(StatusCodes.Status200OK, "The appointment was found", typeof(AppointmentResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The appointment was not found.")]
    public async Task<IActionResult> GetAppointmentById([FromRoute] int appointmentId)
    {
        var getAppointmentByIdQuery = new GetAppointmentByIdQuery(appointmentId);
        var appointment = await appointmentQueryService.Handle(getAppointmentByIdQuery);
        if (appointment is null) return NotFound();
        var appointmentResource = AppointmentResourceFromEntityAssembler.ToResourceFromEntity(appointment);
        return Ok(appointmentResource);
    }

    //TODO: Refactor function and controller location in order to match the following endpoint (api/v1/users/{userId:int}/appointments) (Astonitas)
    /// <summary>
    /// Get appointments by user id
    /// </summary>
    /// <param name="userId">
    /// The id of the user to get appointments for
    /// </param>
    /// <returns>
    /// The <see cref="AppointmentResource"/> resources for the given user id
    /// </returns>
    [HttpGet("user/{userId:int}")]
    [SwaggerOperation(
        Summary = "Get appointments by user id",
        Description = "Get the appointments a user has",
        OperationId = "GetAppointmentsByUserId")]
    [SwaggerResponse(StatusCodes.Status200OK, "The appointments were found", typeof(IEnumerable<AppointmentResource>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The appointments were not found.")]
    public async Task<IActionResult> GetAppointmentsByUserId([FromRoute] int userId)
    {
        var getAllAppointmentsByUserIdQuery = new GetAllAppointmentsByUserIdQuery(userId);
        var appointments = await appointmentQueryService.Handle(getAllAppointmentsByUserIdQuery);
        var appointmentResources = appointments.Select(
            AppointmentResourceFromEntityAssembler.ToResourceFromEntity
            );
        return Ok(appointmentResources);
    }

    /// <summary>
    /// Create a new appointment
    /// </summary>
    /// <param name="resource">
    /// The <see cref="CreateAppointmentResource"/> resource to create
    /// </param>
    /// <returns>
    /// The <see cref="AppointmentResource"/> resource created
    /// </returns>
    [HttpPost]
    [SwaggerOperation(
 Summary = "Create a new appointment",
 Description = "Create a new appointment in the system",
 OperationId = "CreateAppointment")]
    [SwaggerResponse(StatusCodes.Status201Created, "The appointment was created", typeof(AppointmentResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The appointment was not created")]
    public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointmentResource resource)
    {
        var createAppointmentCommand = CreateAppointmentCommandResourceFromEntityAssembler.ToCommandFromResource(resource);
        var appointment = await appointmentCommandService.Handle(createAppointmentCommand);
        if (appointment is null) return NotFound();
        var appointmentResource = AppointmentResourceFromEntityAssembler.ToResourceFromEntity(appointment);

        // 🚩 Aquí ya tienes la cita creada
        // Asumiendo que el Appointment contiene el CompanyId
        var companyId = appointment.Company.Id;

        // 🚩 Buscas la compañía por ID
        var company = await companyQueryService.Handle(new GetCompanyByIdQuery(companyId));
        var companyEmail = company.Email ?? throw new InvalidOperationException("Company email not found");

        // 🚩 Buscas sockets por correo
        List<WebSocket> sockets;
        lock (socketsDictionary)
        {
            sockets = socketsDictionary.ContainsKey(companyEmail)
                ? socketsDictionary[companyEmail].ToList()
                : new List<WebSocket>();
        }

        foreach (var socket in sockets)
        {
            if (socket.State == WebSocketState.Open)
            {
                var messageObject = new
                {
                    type = "notification",
                    content = $"Nueva cita creada por {appointment.User.FirstName} {appointment.User.LastName}"
                };
                var jsonMessage = System.Text.Json.JsonSerializer.Serialize(messageObject);
                var buffer = Encoding.UTF8.GetBytes(jsonMessage);
                await socket.SendAsync(
                    new ArraySegment<byte>(buffer),
                    WebSocketMessageType.Text,
                    true,
                    CancellationToken.None
                );
            }
        }

        return CreatedAtAction(nameof(GetAppointmentById), new { appointmentId = appointment.Id }, appointmentResource);
    }

    /// <summary>
    /// Delete an appointment by id
    /// </summary>
    /// <param name="appointmentId">
    /// The id of the appointment to delete
    /// </param>
    /// <returns>
    /// A message indicating the appointment was deleted
    /// </returns>
    [HttpDelete("{appointmentId:int}")]
    [SwaggerOperation(
     Summary = "Delete an appointment by id",
     Description = "Delete an appointment in a system by its id",
     OperationId = "DeleteAppointmentById")]
    [SwaggerResponse(StatusCodes.Status200OK, "The appointment was deleted", typeof(AppointmentResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The appointment was not found.")]
    public async Task<IActionResult> DeleteAppointmentById([FromRoute] int appointmentId)
    {
        // 1. Obtener la cita para recuperar datos del usuario y la compañía
        var appointment = await appointmentQueryService.Handle(new GetAppointmentByIdQuery(appointmentId));
        if (appointment is null) return NotFound();

        // 2. Eliminar la cita
        var deleteAppointmentCommand = new DeleteAppointmentCommand(appointmentId);
        await appointmentCommandService.Handle(deleteAppointmentCommand);

        // 3. Obtener el CompanyId de la cita
        var companyId = appointment.Company.Id;

        // 4. Buscar la compañía por ID
        var company = await companyQueryService.Handle(new GetCompanyByIdQuery(companyId));
        var companyEmail = company.Email ?? throw new InvalidOperationException("Company email not found");

        // 5. Buscar sockets por correo
        List<WebSocket> sockets;
        lock (socketsDictionary)
        {
            sockets = socketsDictionary.ContainsKey(companyEmail)
                ? socketsDictionary[companyEmail].ToList()
                : new List<WebSocket>();
        }

        // 6. Notificar a cada socket conectado
        foreach (var socket in sockets)
        {
            if (socket.State == WebSocketState.Open)
            {
                var messageObject = new
                {
                    type = "notification",
                    content = $"{appointment.User.FirstName} {appointment.User.LastName} canceló su cita"
                };
                var jsonMessage = System.Text.Json.JsonSerializer.Serialize(messageObject);
                var buffer = Encoding.UTF8.GetBytes(jsonMessage);
                await socket.SendAsync(
                    new ArraySegment<byte>(buffer),
                    WebSocketMessageType.Text,
                    true,
                    CancellationToken.None
                );
            }
        }

        return Ok("The appointment given id successfully deleted");
    }
    [HttpPost("{appointmentId:int}")]
    [SwaggerOperation(
        Summary = "Complete an appointment by id",
        Description = "Complete an appointment in a system by its id",
        OperationId = "CompleteAppointmentById")]
    [SwaggerResponse(StatusCodes.Status200OK, "The appointment was completed", typeof(AppointmentResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The appointment was not found.")]
    public async Task<IActionResult> CompleteAppointmentById([FromRoute] int appointmentId)
    {
        var deleteAppointmentCommand = new CompleteAppoinmentCommand(appointmentId);
        await appointmentCommandService.Handle(deleteAppointmentCommand);
        return Ok("The appointment given id successfully completed");
    }

}