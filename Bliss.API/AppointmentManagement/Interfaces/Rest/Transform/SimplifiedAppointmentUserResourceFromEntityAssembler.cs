
using NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Resources;
using NRG3.Bliss.API.IAM.Domain.Model.Aggregates;

namespace NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Transform;


/// <summary>
/// Assembler to create a SimplifiedUserResource from a User entity
/// </summary>

//TODO: Correct assembler naming (Astonitas)
public static class SimplifiedAppointmentUserResourceFromEntityAssembler
{
    
    /// <summary>
    /// Assembles a SimplifiedUserResource from a User entity
    /// </summary>
    /// <param name="entity">
    /// The <see cref="User"/> entity to assemble the resource from
    /// </param>
    /// <returns>
    /// The <see cref="SimplifiedUserResource"/> resource assembled from the entity
    /// </returns>
    public static SimplifiedUserResource ToResourceFromEntity(User entity)
    {
        return new SimplifiedUserResource(entity.Id, entity.FirstName, entity.LastName, entity.Dni);
    }
}