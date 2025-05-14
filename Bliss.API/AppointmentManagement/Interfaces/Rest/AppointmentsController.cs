using System.Net.Mime;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Commands;
using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Queries;
using NRG3.Bliss.API.AppointmentManagement.Domain.Services;
using NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Resources;
using NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Transform;
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
    IAppointmentQueryService appointmentQueryService
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
    [SwaggerOperation (
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
        var deleteAppointmentCommand = new DeleteAppointmentCommand(appointmentId);
        await appointmentCommandService.Handle(deleteAppointmentCommand);
        return Ok("The appointment given id successfully deleted");
    }
    
}