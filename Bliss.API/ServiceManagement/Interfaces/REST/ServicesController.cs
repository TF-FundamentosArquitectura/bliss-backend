using System.Net.Mime;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Commands;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Queries;
using NRG3.Bliss.API.ServiceManagement.Domain.Services;
using NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Resources;
using NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Transform;
using Swashbuckle.AspNetCore.Annotations;

namespace NRG3.Bliss.API.ServiceManagement.Interfaces.REST;

/**
 * Controller for services
 * <param name="serviceCommandService">
 * The <see cref="IServiceCommandService"/> service to handle commands
 * </param>
 * <param name="serviceQueryService">
 * The <see cref="IServiceQueryService"/> service to handle queries
 *  </param>
 */
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Services")]
public class ServicesController(
    IServiceCommandService serviceCommandService,
    IServiceQueryService serviceQueryService
    ) : ControllerBase
{
    
    /**
     * Get service by id
     * <param name="serviceId">
     * The id of the service to get
     * </param>
     * <returns>
     * The <see cref="ServiceResource"/> resource with the given id
     * </returns>
     */
    [HttpGet("{serviceId:int}")]
    [SwaggerOperation (
        Summary = "Get service by id",
        Description = "Get a service by its id",
        OperationId = "GetServiceById")]
    [SwaggerResponse(StatusCodes.Status200OK, "The service was found", typeof(ServiceResource))]
    public async Task<IActionResult> GetServiceById([FromRoute] int serviceId)
    {
        var getServiceByIdQuery = new GetServiceByIdQuery(serviceId);
        var service = await serviceQueryService.Handle(getServiceByIdQuery);
        if (service is null) return NotFound();
        var serviceResource = ServiceResourceFromEntityAssembler.ToResourceFromEntity(service);
        return Ok(serviceResource);
    }
    
    /**
     * Get all services
     * <returns>
     * The <see cref="ServiceResource"/> resources for all services
     * </returns>
     */
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all services",
        Description = "Get all services in the system",
        OperationId = "GetAllServices")]
    [SwaggerResponse(StatusCodes.Status200OK, "The services were found", typeof(IEnumerable<ServiceResource>))]
    public async Task<IActionResult> GetAllServices()
    {
        var getAllServicesQuery = new GetAllServicesQuery();
        var services = await serviceQueryService.Handle(getAllServicesQuery);
        var serviceResources = services.Select(
            ServiceResourceFromEntityAssembler.ToResourceFromEntity
        );
        return Ok(serviceResources);
    }
    
    /**
     * Create a new service
     * <param name="resource">
     * The <see cref="CreateServiceResource"/> resource to create the service from
     * </param>
     * <returns>
     * The <see cref="ServiceResource"/> resource created
     * </returns>
     */
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new service",
        Description = "Create a new service in the system",
        OperationId = "CreateService")]
    [SwaggerResponse(StatusCodes.Status201Created, "The service was created", typeof(ServiceResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The request is invalid")]
    public async Task<IActionResult> CreateService([FromBody] CreateServiceResource resource)
    {
        var createServiceCommand = CreateServiceCommandResourceFromEntityAssembler.ToCommandFromResource(resource);
        var service = await serviceCommandService.Handle(createServiceCommand);
        if (service is null) return BadRequest("The service could not be created");
        var serviceResource = ServiceResourceFromEntityAssembler.ToResourceFromEntity(service);
        return CreatedAtAction(nameof(GetServiceById), new { serviceId = service.Id }, serviceResource);
    }
    
    /**
     * Update a service
     * <param name="resource">
     * The <see cref="UpdateServiceResource"/> resource to update the service from
     * </param>
     * <param name="serviceId">
     * The id of the service to update
     * </param>
     * <returns>
     * The <see cref="ServiceResource"/> resource updated
     * </returns>
     */
    [HttpPut("{serviceId:int}")]
    [SwaggerOperation(
        Summary = "Update a service",
        Description = "Update a new service in the system",
        OperationId = "UpdateService")]
    [SwaggerResponse(StatusCodes.Status200OK, "The service was updated", typeof(ServiceResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The request is invalid")]
    public async Task<IActionResult> UpdateService([FromBody] UpdateServiceResource resource,[FromRoute] int serviceId)
    {
        var updateServiceCommand = UpdateServiceCommandResourceFromEntityAssembler.ToCommandFromResource(resource, serviceId);
        var service = await serviceCommandService.Handle(updateServiceCommand);
        if (service is null) return BadRequest();
        var serviceResource = ServiceResourceFromEntityAssembler.ToResourceFromEntity(service);
        return Ok(serviceResource);
    }
    
    /**
     * Delete a service
     * <param name="serviceId">
     * The id of the service to delete
     * </param>
     * <returns>
     * A message indicating the service was deleted
     * </returns>
     */
    [HttpDelete("{serviceId:int}")]
    [SwaggerOperation(
        Summary = "Delete a service",
        Description = "Delete a service in the system",
        OperationId = "DeleteService")]
    [SwaggerResponse(StatusCodes.Status200OK, "The service was deleted")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The request is invalid")]
    public async Task<IActionResult> DeleteServiceById([FromRoute] int serviceId)
    {
        var deleteServiceCommand = new DeleteServiceCommand(serviceId);
        await serviceCommandService.Handle(deleteServiceCommand);
        return Ok("The service with the given id was successfully deleted");
    }
}