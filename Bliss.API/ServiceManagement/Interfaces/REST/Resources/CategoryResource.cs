namespace NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Resources;

/**
 * Represents a category resource.
 * <param name="Id">
 * The unique identifier of the category.
 * </param>
 * <param name="Name ">
 * The name of the category.
 * </param>
 * <param name="Description">
 * The description of the category.
 * </param>
 */
public record CategoryResource(int Id, string Name, string Description);