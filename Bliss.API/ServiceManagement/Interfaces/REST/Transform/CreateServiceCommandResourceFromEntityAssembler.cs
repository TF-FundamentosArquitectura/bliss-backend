using NRG3.Bliss.API.ServiceManagement.Domain.Model.Commands;
using NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Resources;

namespace NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Transform;

/**
 * Assembler to create a CreateServiceCommand from a CreateServiceResource
 */
public static class CreateServiceCommandResourceFromEntityAssembler
{
    /**
     * Assembles a CreateServiceCommand from a CreateServiceResource
     * <param name="resource">
     * The <see cref="CreateServiceResource"/> resource to assemble the command from
     * </param>
     * <returns>
     * The <see cref="CreateServiceCommand"/> command assembled from the resource
     * </returns>
     */
    public static CreateServiceCommand ToCommandFromResource(CreateServiceResource resource)
    {
        return new CreateServiceCommand(resource.CompanyId, resource.CategoryId, resource.Name, resource.Description, resource.Price, resource.Duration, resource.ImageUrl);
    }
}