namespace NRG3.Bliss.API.AppointmentManagement.Domain.Model.Queries;

/// <summary>
/// Get all appointments by user id query
/// </summary>
/// <param name="UserId">
/// The user id to get appointments for
/// </param>
public record GetAllAppointmentsByUserIdQuery(int UserId);