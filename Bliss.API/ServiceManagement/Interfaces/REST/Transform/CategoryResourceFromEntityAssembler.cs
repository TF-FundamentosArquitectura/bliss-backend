using NRG3.Bliss.API.ServiceManagement.Domain.Model.Entities;
using NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Resources;

namespace NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Transform;

/**
 * Assembler to create a CategoryResource from a Category entity
 */
public static class CategoryResourceFromEntityAssembler
{
    /**
     * Assembles a CategoryResource from a Category entity
     * <param name="entity">
     * The <see cref="Category"/> entity to assemble the resource from
     * </param>
     * <returns>
     * The <see cref="CategoryResource"/> resource assembled from the entity
     * </returns>
     */
    public static CategoryResource ToResourceFromEntity(Category entity)
    {
        return new CategoryResource(entity.Id, entity.Name, entity.Description);
    }
}