using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Commands;
using NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Resources;

namespace NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Transform;

/// <summary>
/// Assembler to create a CreateAppointmentCommand from a CreateAppointmentResource
/// </summary>
public static class CreateAppointmentCommandResourceFromEntityAssembler
{
    /// <summary>
    /// Assembles a CreateAppointmentCommand from a CreateAppointmentResource
    /// </summary>
    /// <param name="resource">
    /// The <see cref="CreateAppointmentResource"/> resource to assemble the command from
    /// </param>
    /// <returns>
    /// The <see cref="CreateAppointmentCommand"/> command assembled from the resource
    /// </returns>
    public static CreateAppointmentCommand ToCommandFromResource(CreateAppointmentResource resource)
    {
        return new CreateAppointmentCommand(
            resource.userId,
            resource.companyId,
            resource.serviceId,
            resource.reservationDate,
            resource.status,
            resource.date,
            resource.time,
            resource.requirements
            );
    }
}