namespace NRG3.Bliss.API.AppointmentManagement.Domain.Model.Commands;

/// <summary>
/// Create appointment command
/// </summary>
/// <param name="UserId">
/// The user id to create the appointment for
/// </param>
/// <param name="CompanyId">
/// The company id to create the appointment for
/// </param>
/// <param name="ServiceId">
/// The service id to create the appointment for
/// </param>
/// <param name="ReservedAt">
/// The date and time the appointment was reserved
/// </param>
/// <param name="Status">
/// The status of the appointment
/// </param>
/// <param name="ReservationDate">
/// The date of the appointment
/// </param>
/// <param name="ReservationStartTime">
/// The start time of the appointment
/// </param>
/// <param name="Requirements">
/// The requirements for the appointment
/// </param>
public record CreateAppointmentCommand( int UserId, int CompanyId, int ServiceId,DateTime ReservedAt, string Status, DateTime ReservationDate, string ReservationStartTime, string Requirements);