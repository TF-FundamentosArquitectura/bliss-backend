using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Queries;
using NRG3.Bliss.API.AppointmentManagement.Domain.Repositories;
using NRG3.Bliss.API.AppointmentManagement.Domain.Services;

namespace NRG3.Bliss.API.AppointmentManagement.Application.Internal.QueryServices;

/// <summary>
/// Appointment query service
/// </summary>
/// <param name="appointmentRepository">
/// Appointment repository
/// </param>
public class AppointmentQueryService(IAppointmentRepository appointmentRepository) : IAppointmentQueryService
{
    /// <inheritdoc />
    public async Task<IEnumerable<Appointment>> Handle(GetAllAppointmentsByUserIdQuery query)
    {
        return await appointmentRepository.FindAppointmentsByUserIdAsync(query.UserId);
    }

    /// <inheritdoc />
    public async Task<Appointment?> Handle(GetAppointmentByIdQuery query)
    {
        return await appointmentRepository.FindAppointmentByIdAsync(query.AppointmentId);
    }

    public async Task<IEnumerable<Appointment>> Handle(GetAppointmentByCompanyId query)
    {
        return await appointmentRepository.FindAppointmentsByCompanyIdAsync(query.CompanyId);
    }
}