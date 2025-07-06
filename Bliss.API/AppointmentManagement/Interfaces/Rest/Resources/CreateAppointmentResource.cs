namespace NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Resources;

/// <summary>
/// Resource for an appointment creation
/// </summary>
/// <param name="userId">
/// The unique identifier of the user
/// </param>
/// <param name="serviceId">
/// The unique identifier of the service
/// </param>
/// <param name="companyId">
/// The unique identifier of the company
/// </param>
/// <param name="reservationDate">
/// The reservation date of the appointment
/// </param>
/// <param name="status">
/// The status of the appointment
/// </param>
/// <param name="date">
/// The date of the appointment
/// </param>
/// <param name="time">
/// The time of the appointment
/// </param>
/// <param name="requirements">
/// The requirements of the appointment
/// </param>
public record CreateAppointmentResource(
    int userId,
    int serviceId,
    int companyId,
    DateTime reservationDate,
    string status,
    DateTime date,
    string time,
    string requirements,
    string specialist
    );