namespace NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Resources;

/**
 * Represents a service category resource.
 * <param name="Id">
 * The unique identifier of the service category.
 * </param>
 * <param name="Name">
 * The name of the service category.
 * </param>
 */
public record ServiceCategoryResource(int Id, string Name);