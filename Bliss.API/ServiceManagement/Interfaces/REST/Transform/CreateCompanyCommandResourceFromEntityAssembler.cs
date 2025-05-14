using NRG3.Bliss.API.ServiceManagement.Domain.Model.Commands;
using NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Resources;

namespace NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Transform;

/**
 * Assembler to create a CreateCompanyCommand from a CreateCompanyResource
 */
public static class CreateCompanyCommandResourceFromEntityAssembler
{
    /**
     * Assembles a CreateCompanyCommand from a CreateCompanyResource
     * <param name="resource">
     * The <see cref="CreateCompanyResource"/> resource to assemble the command from
     * </param>
     * <returns>
     * The <see cref="CreateCompanyCommand"/> command assembled from the resource
     * </returns>
     */
    public static CreateCompanyCommand ToCommandFromResource(CreateCompanyResource resource)
    {
        return new CreateCompanyCommand(resource.Name, resource.Ruc, resource.Email, resource.WebsiteUrl, resource.PhoneNumber, resource.Description);
    }
}