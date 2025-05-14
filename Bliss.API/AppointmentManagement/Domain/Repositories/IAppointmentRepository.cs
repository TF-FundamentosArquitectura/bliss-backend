using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.Shared.Domain.Repositories;

namespace NRG3.Bliss.API.AppointmentManagement.Domain.Repositories;

/// <summary>
/// Appointment repository interface
/// </summary>
public interface IAppointmentRepository : IBaseRepository<Appointment>
{
    //TODO: Change the return types to boolean on validation methods (Astonitas)
    
    /// <summary>
    /// Find appointments by user id
    /// </summary>
    /// <param name="userId">
    /// The user id to search for
    /// </param>
    /// <returns>
    /// The <see cref="Appointment"/> if found, otherwise null
    /// </returns>
    Task<IEnumerable<Appointment>> FindAppointmentsByUserIdAsync(int userId);
    
    /// <summary>
    /// Find appointments by service id
    /// </summary>
    /// <param name="serviceId">
    /// The service id to search for
    /// </param>
    /// <param name="reservationDate">
    /// The reservation date to search for
    /// </param>
    /// <param name="reservationStartTime">
    /// The reservation start time to search for
    /// </param>
    /// <returns>
    /// The <see cref="Appointment"/> if found, otherwise null
    /// </returns>
    Task<Appointment?> FindByServiceIdAndTimeAsync(int serviceId, DateTime reservationDate, string reservationStartTime);
    
    /// <summary>
    /// Find appointments by company id
    /// </summary>
    /// <param name="userId">
    /// The company id to search for
    /// </param>
    /// <param name="reservationDate">
    /// The reservation date to search for
    /// </param>
    /// <param name="reservationStartTime">
    /// The reservation start time to search for
    /// </param>
    /// <returns>
    /// The <see cref="Appointment"/> if found, otherwise null
    /// </returns>
    Task<Appointment?> FindByUserIdAndTimeAsync(int userId, DateTime reservationDate, string reservationStartTime);
    
    /// <summary>
    /// Find appointment by id
    /// </summary>
    /// <param name="appointmentId">
    /// The appointment id to search for
    /// </param>
    /// <returns>
    /// The <see cref="Appointment"/> if found, otherwise null
    /// </returns>
    Task<Appointment?> FindAppointmentByIdAsync(int appointmentId);
    
    /// <summary>
    ///  Find appointment by company id
    /// </summary>
    /// <param name="companyId">
    /// The company id to search for 
    /// </param>
    /// <returns>
    /// The <see cref="Appointment"/> if found, otherwise null
    /// </returns>
    Task<IEnumerable<Appointment>> FindAppointmentsByCompanyIdAsync(int companyId);
    
}