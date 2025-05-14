using NRG3.Bliss.API.ServiceManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Queries;

namespace NRG3.Bliss.API.ServiceManagement.Domain.Services;

public interface IServiceQueryService
{
    /**
     * Handle get all services query
     * <summary>
     * This method is used to handle the get all services query.
     * </summary>
     * <param name="query">The get all services query</param>
     * <returns>The list of services</returns>
     */
    Task<IEnumerable<Service>> Handle(GetAllServicesQuery query);
    /**
     * Handle get service by id query
     * <summary>
     * This method is used to handle the get service by id query.
     * </summary>
     * <param name="query">The get service by id query</param>
     * <returns>The service</returns>
     */
    Task<Service?> Handle(GetServiceByIdQuery query);
    /**
     * Handle get all services by company id query
     * <summary>
     * This method is used to handle the get all services by company id query.
     * </summary>
     * <param name="query">The get all services by company id query</param>
     * <returns>The list of services</returns>
     */
    Task<IEnumerable<Service>> Handle(GetAllServicesByCompanyIdQuery query);
}