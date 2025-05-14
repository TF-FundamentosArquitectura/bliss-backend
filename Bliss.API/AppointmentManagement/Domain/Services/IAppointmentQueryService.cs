using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Queries;

namespace NRG3.Bliss.API.AppointmentManagement.Domain.Services;

/// <summary>
/// Appointment query service interface
/// </summary>
public interface IAppointmentQueryService
{
    /// <summary>
    /// Handle get all appointments by user id query
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetAllAppointmentsByUserIdQuery"/> query
    /// </param>
    /// <returns>
    /// The <see cref="IEnumerable{Appointment}"/> object with the appointments
    /// </returns>
    Task<IEnumerable<Appointment>> Handle(GetAllAppointmentsByUserIdQuery query);
    
    /// <summary>
    /// Handle get appointment by id query
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetAppointmentByIdQuery"/> query
    /// </param>
    /// <returns>
    /// The <see cref="Appointment"/> object with the appointment
    /// </returns>
    Task<Appointment?> Handle(GetAppointmentByIdQuery query);
    /// <summary>
    /// Handle get appointment by company id query
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetAppointmentByCompanyId"/> query
    /// </param>
    /// <returns>
    /// The <see cref="Appointment"/> object with the appointment
    /// </returns>
    Task<IEnumerable<Appointment>> Handle(GetAppointmentByCompanyId query);
    
}