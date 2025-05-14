using NRG3.Bliss.API.ServiceManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.Shared.Domain.Repositories;

namespace NRG3.Bliss.API.ServiceManagement.Domain.Repositories;

public interface IServiceRepository : IBaseRepository<Service>
{
    /**
     * Find services by company id
     * <summary>
     * This method is used to find services by company id.
     * </summary>
     * <param name="companyId">The company id</param>
     * <returns>The list of services</returns>
     */
    Task<IEnumerable<Service>> FindServicesByCompanyIdAsync(int companyId);
    /**
     * Find all services
     * <summary>
     * This method is used to find all services.
     * </summary>
     * <returns>The list of services</returns>
     */
    Task<IEnumerable<Service>> FindAllServices();
    /**
     * Find service by id
     * <summary>
     * This method is used to find a service by id.
     * </summary>
     * <param name="serviceId">The service id</param>
     * <returns>The service</returns>
     */
    Task<Service?> FindServiceById(int serviceId);
    /**
     * Service name exists for company and category
     * <summary>
     * This method is used to check if a service name exists for a company and category.
     * </summary>
     * <param name="companyId">The company id</param>
     * <param name="categoryId">The category id</param>
     * <param name="serviceName">The service name</param>
     * <returns>True if the service name exists, false otherwise</returns>
     */
    Task<bool> ServiceNameExistsForCompanyAndCategoryAsync(int companyId, int categoryId, string serviceName);
}