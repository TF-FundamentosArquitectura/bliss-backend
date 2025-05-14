using NRG3.Bliss.API.Shared.Interfaces.REST.Resources;

namespace NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Resources;

/**
 * Represents a service resource.
 * <param name="Id">
 * The unique identifier of the service.
 * </param>
 * <param name="Company">
 * The company that provides the service.
 * </param>
 * <param name="Category">
 * The category of the service.
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
 * <param name="ImgUrl">
 * The image URL of the service.
 * </param>
 */
public record ServiceResource(int Id, SimplifiedCompanyResource Company, ServiceCategoryResource Category, string Name, string Description, double Price, double Duration,string ImgUrl);