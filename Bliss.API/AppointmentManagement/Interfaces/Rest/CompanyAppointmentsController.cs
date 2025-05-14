using System.Net.Mime;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Queries;
using NRG3.Bliss.API.AppointmentManagement.Domain.Services;
using NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Resources;
using NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Transform;
using Swashbuckle.AspNetCore.Annotations;

namespace NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest;

[ApiController]
[Route("api/v1/companies/{companyId}/appointments")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Appointments")]
public class CompanyAppointmentsController(IAppointmentQueryService appointmentQueryService) : ControllerBase
{
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get appointment by company id",
        Description = "Get an appointment by the company id it has",
        OperationId = "GetAppointmentByCompanyId")]
    [SwaggerResponse(StatusCodes.Status200OK, "The appointment was found", typeof(IEnumerable<AppointmentResource>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The appointment was not found.")]
   
    public async Task<IActionResult> GetAppointmentByCompanyId([FromRoute] int companyId)
    {
        var getAppointmentByCompanyIdQuery = new GetAppointmentByCompanyId(companyId);
        var appointments = await appointmentQueryService.Handle(getAppointmentByCompanyIdQuery);
        var appointmentResources = appointments.Select(AppointmentResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(appointmentResources);
    }
}