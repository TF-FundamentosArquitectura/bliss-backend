using NRG3.Bliss.API.ServiceManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Resources;
using NRG3.Bliss.API.Shared.Interfaces.REST.Transform;

namespace NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Transform;

/**
 * Assembler to create a ServiceResource from a Service entity
 */
public static class ServiceResourceFromEntityAssembler
{
    /**
     * Assembles a ServiceResource from a Service entity
     * <param name="entity">
     * The <see cref="Service"/> entity to assemble the resource from
     * </param>
     * <returns>
     * The <see cref="ServiceResource"/> resource assembled from the entity
     * </returns>
     */
    public static ServiceResource ToResourceFromEntity(Service entity)
    {
        return new ServiceResource(
            entity.Id, 
            SimplifiedCompanyResourceFromEntityAssembler.ToResourceFromEntity(entity.Company), 
            ServiceCategoryResourceFromEntityAssembler.ToResourceFromEntity(entity.Category),
            entity.Name,
            entity.Description,
            entity.Price,
            entity.Duration,
            entity.ImageUrl
        );
    }
}