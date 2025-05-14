namespace NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Resources;

/**
 * Represents a service resource.
 * <param name="CompanyId">
 * The unique identifier of the company.
 * </param>
 * <param name="CategoryId">
 * The unique identifier of the category.
 * </param>
 * <param name="Name">
 * The name of the service.
 * </param>
 * <param name="Description">
 * The description of the service.
 * </param>
 * <param name="Price">
 * The price of the service.
 * </param>
 * <param name="Duration">
 * The duration of the service.
 * </param>
 * <param name="ImageUrl">
 * The image URL of the service.
 * </param>
 */
public record CreateServiceResource(int CompanyId,int CategoryId, string Name, string Description, double Price, double Duration, string ImageUrl);