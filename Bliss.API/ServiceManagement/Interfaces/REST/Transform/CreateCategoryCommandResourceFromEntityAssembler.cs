using NRG3.Bliss.API.ServiceManagement.Domain.Model.Commands;
using NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Resources;

namespace NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Transform;

/**
 * Assembler to create a CreateCategoryCommand from a CreateCategoryResource
 */
public static class CreateCategoryCommandResourceFromEntityAssembler
{
    /**
     * Assembles a CreateCategoryCommand from a CreateCategoryResource
     * <param name="resource">
     * The <see cref="CreateCategoryResource"/> resource to assemble the command from
     * </param>
     * <returns>
     * The <see cref="CreateCategoryCommand"/> command assembled from the resource
     * </returns>
     */
    public static CreateCategoryCommand ToCommandFromResource(CreateCategoryResource resource)
    {
        return new CreateCategoryCommand(resource.Name, resource.Description);
    }
}