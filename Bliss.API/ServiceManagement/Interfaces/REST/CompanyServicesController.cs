using System.Net.Mime;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Queries;
using NRG3.Bliss.API.ServiceManagement.Domain.Services;
using NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Resources;
using NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Transform;
using Swashbuckle.AspNetCore.Annotations;

namespace NRG3.Bliss.API.ServiceManagement.Interfaces.REST;

/**
 * Controller for company services
 */
[ApiController]
[Route("api/v1/companies/{companyId}/services")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Services")]

public class CompanyServicesController(IServiceQueryService serviceQueryService, IServiceCommandService serviceCommandService) : ControllerBase
{
    /**
     * Get all services by company id
     * <param name="companyId">
     * The id of the company to get the services for
     * </param>
     * <returns>
     * The <see cref="ServiceResource"/> resources for the company with the given id
     * </returns>
     */
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all services by company id",
        Description = "Get all services for a company in the system",
        OperationId = "GetServicesByCompanyId")]
    [SwaggerResponse(StatusCodes.Status200OK, "The services with the given company id", typeof(IEnumerable<ServiceResource>))]
    public async Task<IActionResult> GetServicesByCompanyId([FromRoute] int companyId)
    {
        var getAllServicesByCompanyIdQuery = new GetAllServicesByCompanyIdQuery(companyId);
        var services = await serviceQueryService.Handle(getAllServicesByCompanyIdQuery);

        if (services is null || !services.Any())
            return NotFound();

        var serviceResources = new List<ServiceResource>();

        foreach (var service in services)
        {
            var specialists = await serviceCommandService.getSpecialist(service.Id);
            var resource = ServiceResourceFromEntityAssembler.ToResourceFromEntity(service, specialists);
            serviceResources.Add(resource);
        }

        return Ok(serviceResources);
    }

}