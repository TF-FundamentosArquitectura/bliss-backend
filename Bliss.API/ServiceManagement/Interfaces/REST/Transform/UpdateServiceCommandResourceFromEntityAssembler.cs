using NRG3.Bliss.API.ServiceManagement.Domain.Model.Commands;
using NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Resources;

namespace NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Transform;

/**
 * Assembler to create a UpdateServiceCommand from a UpdateServiceResource
 */
public class UpdateServiceCommandResourceFromEntityAssembler
{
    /**
     * Assembles a UpdateServiceCommand from a UpdateServiceResource
     * <param name="resource">
     * The <see cref="UpdateServiceResource"/> resource to assemble the command from
     * </param>
     * <param name="serviceId">
     * The id of the service to update
     * </param>
     * <returns>
     * The <see cref="UpdateServiceCommand"/> command assembled from the resource
     * </returns>
     */
    public static UpdateServiceCommand ToCommandFromResource(UpdateServiceResource resource, int serviceId)
    {
        return new UpdateServiceCommand(
            serviceId, resource.CategoryId, 
            resource.Name, resource.Description,
            resource.Price, resource.Duration);
    }
}