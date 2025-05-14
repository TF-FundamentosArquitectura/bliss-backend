using NRG3.Bliss.API.ServiceManagement.Domain.Model.Entities;
using NRG3.Bliss.API.Shared.Interfaces.REST.Resources;

namespace NRG3.Bliss.API.Shared.Interfaces.REST.Transform;

public static class SimplifiedCompanyResourceFromEntityAssembler
{
    public static SimplifiedCompanyResource ToResourceFromEntity(Company entity)
    {
        return new SimplifiedCompanyResource(entity.Id, entity.Name);
    }
}