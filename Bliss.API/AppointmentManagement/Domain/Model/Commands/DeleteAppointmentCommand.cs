namespace NRG3.Bliss.API.AppointmentManagement.Domain.Model.Commands;

/// <summary>
/// Delete appointment command
/// </summary>
/// <param name="appointmentId">
/// The appointment id to delete
/// </param>
public record DeleteAppointmentCommand(int appointmentId);