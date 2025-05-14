using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Commands;

namespace NRG3.Bliss.API.AppointmentManagement.Domain.Services;

/// <summary>
/// Appointment command service interface
/// </summary>
public interface IAppointmentCommandService
{
    /// <summary>
    /// Handle create appointment command
    /// </summary>
    /// <param name="command">
    /// The <see cref="CreateAppointmentCommand"/> command
    /// </param>
    /// <returns>
    /// The <see cref="Appointment"/> object with the created appointment
    /// </returns>
    Task<Appointment?> Handle(CreateAppointmentCommand command);
    
    /// <summary>
    /// Handle delete appointment command
    /// </summary>
    /// <param name="command">
    /// The <see cref="DeleteAppointmentCommand"/> command
    /// </param>
    /// <returns>
    /// The <see cref="Task"/> object
    /// </returns>
    Task Handle(DeleteAppointmentCommand command);
}