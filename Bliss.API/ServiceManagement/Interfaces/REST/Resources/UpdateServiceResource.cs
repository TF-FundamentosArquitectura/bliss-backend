namespace NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Resources;

/**
 * Represents a service resource.
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
 */
public record UpdateServiceResource(int CategoryId, string Name, string Description, double Price, double Duration);