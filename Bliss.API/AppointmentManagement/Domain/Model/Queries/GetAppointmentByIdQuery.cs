namespace NRG3.Bliss.API.AppointmentManagement.Domain.Model.Queries;

/// <summary>
/// Get appointment by id query
/// </summary>
/// <param name="AppointmentId">
/// The appointment id to get
/// </param>
public record GetAppointmentByIdQuery(int AppointmentId);