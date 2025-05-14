using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Commands;
using NRG3.Bliss.API.AppointmentManagement.Domain.Repositories;
using NRG3.Bliss.API.AppointmentManagement.Domain.Services;
using NRG3.Bliss.API.ServiceManagement.Domain.Repositories;
using NRG3.Bliss.API.Shared.Domain.Repositories;

namespace NRG3.Bliss.API.AppointmentManagement.Application.Internal.CommandServices;

/// <summary>
/// Appointment command service
/// </summary>
/// <param name="appointmentRepository">
/// Appointment repository
/// </param>
/// <param name="userRepository">
/// User repository
/// </param>
/// <param name="serviceRepository">
/// Service repository
/// </param>
/// <param name="companyRepository">
/// Company repository
/// </param>
/// <param name="unitOfWork">
/// Unit of work
/// </param>
public class AppointmentCommandService(
    IAppointmentRepository appointmentRepository,
    IUserRepository userRepository,
    IServiceRepository serviceRepository,
    ICompanyRepository companyRepository,
    IUnitOfWork unitOfWork)
    : IAppointmentCommandService
{
    /// <inheritdoc />
    public async Task<Appointment?> Handle(CreateAppointmentCommand command)
    {
        
        var existingAppointment = await appointmentRepository.FindByServiceIdAndTimeAsync(command.ServiceId, command.ReservationDate, command.ReservationStartTime);
        if (existingAppointment != null)
        {
            throw new InvalidOperationException("An appointment for this service at the specified time already exists.");
        }
        
        var userAppointment = await appointmentRepository.FindByUserIdAndTimeAsync(command.UserId, command.ReservationDate, command.ReservationStartTime);
        if (userAppointment != null)
        {
            throw new InvalidOperationException("The user already has an appointment at the specified time.");
        }
        
        var appointment = new Appointment(command);
        
        await appointmentRepository.AddAsync(appointment);
        await unitOfWork.CompleteAsync();
        
        var user = await userRepository.FindByIdAsync(command.UserId);
        var service = await serviceRepository.FindByIdAsync(command.ServiceId);
        var company = await companyRepository.FindByIdAsync(command.CompanyId);
        
        if (service != null) appointment.ServiceId = service.Id;
        if (company != null) appointment.CompanyId = company.Id;
        if (user != null) appointment.UserId = user.Id;
        
        return appointment; 
    }

    /// <inheritdoc />
    public async Task Handle(DeleteAppointmentCommand command)
    {
        var appointment = await appointmentRepository.FindByIdAsync(command.appointmentId);
        
        if (appointment != null)
        {
            appointmentRepository.Remove(appointment);
            await unitOfWork.CompleteAsync();
        }


    }
}