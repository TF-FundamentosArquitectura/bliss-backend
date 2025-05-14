namespace NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Resources;

/**
 * Represents a category resource.
 * <param name="Name ">
 * The name of the category.
 * </param>
 * <param name="Description">
 * The description of the category.
 * </param>
 */
public record CreateCategoryResource(string Name, string Description);