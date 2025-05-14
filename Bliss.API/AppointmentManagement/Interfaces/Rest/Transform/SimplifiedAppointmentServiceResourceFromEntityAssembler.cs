using NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Resources;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Aggregates;

namespace NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Transform;


/// <summary>
/// Assembler to create a SimplifiedServiceResource from a Service entity
/// </summary>

//TODO: Correct assembler naming (Astonitas)
public static class SimplifiedAppointmentServiceResourceFromEntityAssembler
{
    /// <summary>
    /// Assembles a SimplifiedServiceResource from a Service entity
    /// </summary>
    /// <param name="entity">
    /// The <see cref="Service"/> entity to assemble the resource from
    /// </param>
    /// <returns>
    /// The <see cref="SimplifiedServiceResource"/> resource assembled from the entity
    /// </returns>
    public static SimplifiedServiceResource ToResourceFromEntity(Service entity)
    {
        return new SimplifiedServiceResource(entity.Id, entity.Name,entity.Price);
    }
}