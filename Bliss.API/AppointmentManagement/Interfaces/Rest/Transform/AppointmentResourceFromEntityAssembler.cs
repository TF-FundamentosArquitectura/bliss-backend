using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Resources;
using NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Transform;
using NRG3.Bliss.API.Shared.Interfaces.REST.Transform;

namespace NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Transform;

/// <summary>
/// Assembler to create a AppointmentResource from a Appointment entity
/// </summary>
public static class AppointmentResourceFromEntityAssembler
{
    
    /// <summary>
    /// Assembles a AppointmentResource from a Appointment entity
    /// </summary>
    /// <param name="entity">
    /// The <see cref="Appointment"/> entity to assemble the resource from
    /// </param>
    /// <returns>
    /// The <see cref="AppointmentResource"/> resource assembled from the entity
    /// </returns>
    public static AppointmentResource ToResourceFromEntity(Appointment entity)
    {
        return new AppointmentResource(
            entity.Id,
            SimplifiedAppointmentUserResourceFromEntityAssembler.ToResourceFromEntity(entity.User), 
            SimplifiedAppointmentServiceResourceFromEntityAssembler.ToResourceFromEntity(entity.Service),
            SimplifiedCompanyResourceFromEntityAssembler.ToResourceFromEntity(entity.Company),
            entity.CreatedDate,
            entity.Status,
            entity.ReservationDate,
            entity.ReservationStartTime,
            entity.Requirements
        );
    }
}