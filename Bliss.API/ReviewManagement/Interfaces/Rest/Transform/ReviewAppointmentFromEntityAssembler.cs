using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Transform;
using NRG3.Bliss.API.ReviewManagement.Interfaces.Rest.Resources;

namespace NRG3.Bliss.API.ReviewManagement.Interfaces.Rest.Transform;

//TODO: Correct naming of the class to match resource name (Elvia)
public static class ReviewAppointmentFromEntityAssembler
{
    public static ReviewAppointmentResource ToResourceFromEntity(Appointment appointment)
    {
        if (appointment.Service == null)
        {
            throw new ArgumentException("Service cannot be null", nameof(appointment.Service));
        }

        if (appointment.Company == null)
        {
            throw new ArgumentException("Company cannot be null", nameof(appointment.Company));
        }

        var simplifiedServiceResource = SimplifiedAppointmentServiceResourceFromEntityAssembler.ToResourceFromEntity(appointment.Service);
        var simplifiedCompanyResource = ReviewCompanyAppointmentFromEntityAssembler.ToResourceFromEntity(appointment.Company);

        return new ReviewAppointmentResource(
            simplifiedServiceResource.ServiceName,
            simplifiedCompanyResource.Name,
            appointment.ReservationStartTime,
            appointment.UserId
        );
    }
}