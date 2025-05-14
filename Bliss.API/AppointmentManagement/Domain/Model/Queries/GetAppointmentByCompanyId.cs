namespace NRG3.Bliss.API.AppointmentManagement.Domain.Model.Queries;
/// <summary>
/// Get appointment by company id query
/// </summary>
/// <param name="CompanyId">
/// The company id to get appointments for 
/// </param>
public record GetAppointmentByCompanyId(int CompanyId);