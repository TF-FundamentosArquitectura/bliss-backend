using NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Resources;
using NRG3.Bliss.API.Shared.Interfaces.REST.Resources;

namespace NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Resources;

/// <summary>
/// Resource for an appointment
/// </summary>
/// <param name="id">
/// The unique identifier of the appointment
/// </param>
/// <param name="user">
/// The user of the appointment
/// </param>
/// <param name="service">
/// The service of the appointment
/// </param>
/// <param name="company">
/// The company of the appointment
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
public record AppointmentResource(
    int id,
    SimplifiedUserResource user,
    SimplifiedServiceResource service,
    SimplifiedCompanyResource company,
    DateTimeOffset? reservationDate,
    string status,
    DateTime date,
    string time,
    string requirements,
    string specialist
    );