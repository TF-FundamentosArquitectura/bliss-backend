using NRG3.Bliss.API.ServiceManagement.Domain.Model.Entities;
using NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Resources;

namespace NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Transform;

/**
 * Assembler to create a ServiceCategoryResource from a Category entity
 */
public class ServiceCategoryResourceFromEntityAssembler
{
    /**
     * Assembles a ServiceCategoryResource from a Category entity
     * <param name="entity">
     * The <see cref="Category"/> entity to assemble the resource from
     * </param>
     * <returns>
     * The <see cref="ServiceCategoryResource"/> resource assembled from the entity
     * </returns>
     */
    public static ServiceCategoryResource ToResourceFromEntity(Category entity)
    {
        return new ServiceCategoryResource(entity.Id, entity.Name);
    }
}