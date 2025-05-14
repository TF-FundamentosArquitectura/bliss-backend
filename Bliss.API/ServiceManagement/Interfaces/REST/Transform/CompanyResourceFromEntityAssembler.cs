using NRG3.Bliss.API.ServiceManagement.Domain.Model.Entities;
using NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Resources;

namespace NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Transform;

/**
 * Assembler to create a CompanyResource from a Company entity
 */
public static class CompanyResourceFromEntityAssembler
{
    /**
     * Assembles a CompanyResource from a Company entity
     * <param name="entity">
     * The <see cref="Company"/> entity to assemble the resource from
     * </param>
     * <returns>
     * The <see cref="CompanyResource"/> resource assembled from the entity
     * </returns>
     */
    public static CompanyResource ToResourceFromEntity(Company entity)
    {
        return new CompanyResource(entity.Id, entity.Name, entity.Ruc, entity.Email, entity.WebsiteUrl, entity.PhoneNumber, entity.Description);
    }
}