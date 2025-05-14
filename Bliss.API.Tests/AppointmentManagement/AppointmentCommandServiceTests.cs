using NRG3.Bliss.API.IAM.Domain.Model.Aggregates;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Entities;
using NRG3.Bliss.API.ServiceManagement.Domain.Repositories;

namespace NRG3.Bliss.API.Tests.AppointmentManagement;

using Moq;
using Xunit;
using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Commands;
using NRG3.Bliss.API.AppointmentManagement.Domain.Repositories;
using NRG3.Bliss.API.AppointmentManagement.Application.Internal.CommandServices;
using NRG3.Bliss.API.Shared.Domain.Repositories;

public class AppointmentCommandServiceTests
{
    private readonly Mock<IAppointmentRepository> mockAppointmentRepository;
    private readonly Mock<IUserRepository> mockUserRepository;
    private readonly Mock<IServiceRepository> mockServiceRepository;
    private readonly Mock<ICompanyRepository> mockCompanyRepository;
    private readonly Mock<IUnitOfWork> mockUnitOfWork;
    private readonly AppointmentCommandService appointmentCommandService;

    public AppointmentCommandServiceTests()
    {
     mockAppointmentRepository = new Mock<IAppointmentRepository>();
        mockUserRepository = new Mock<IUserRepository>();
        mockServiceRepository = new Mock<IServiceRepository>();
        mockCompanyRepository = new Mock<ICompanyRepository>();
        mockUnitOfWork = new Mock<IUnitOfWork>();

        appointmentCommandService = new AppointmentCommandService(
            mockAppointmentRepository.Object,
            mockUserRepository.Object,
            mockServiceRepository.Object,
            mockCompanyRepository.Object,
            mockUnitOfWork.Object
        );
    }

    [Fact]
    public async Task Handle_CreateAppointmentCommand_ShouldCreateAppointmentWhenNoConflicts()
    {
        // Arrange
        int userId = 1;
        int serviceId = 1;
        int companyId = 1;
        DateTime registerAt = DateTime.Now;
        string status = "Pending";
        DateTime reservationDate = DateTime.Today;
        string reservationStartTime = "10:00:00";
        string requirements = "Requirements";
        
        var command = new CreateAppointmentCommand(
            userId,
            serviceId,
            companyId,
            registerAt,
            status,
            reservationDate,
            reservationStartTime,
            requirements
        );

        // Configura los repositorios para devolver null indicando que no hay conflictos
        mockAppointmentRepository
            .Setup(repo => repo.FindByServiceIdAndTimeAsync(command.ServiceId, command.ReservationDate, command.ReservationStartTime))
            .ReturnsAsync((Appointment?)null);
        mockAppointmentRepository
            .Setup(repo => repo.FindByUserIdAndTimeAsync(command.UserId, command.ReservationDate, command.ReservationStartTime))
            .ReturnsAsync((Appointment?)null);

        mockUserRepository
            .Setup(repo => repo.FindByIdAsync(command.UserId))
            .ReturnsAsync(new User("John", "Doe", "password123", "john.doe@example.com", "1234567890", "12345678", "123 Main St", "City", DateTime.Parse("1990-01-01")));
        
        mockServiceRepository
            .Setup(repo => repo.FindByIdAsync(command.ServiceId))
            .ReturnsAsync(new Service(command.CompanyId, 1, "ServiceName", "Description", 100.0, 1.0, "example.com"));
        
        mockCompanyRepository
            .Setup(repo => repo.FindByIdAsync(command.CompanyId))
            .ReturnsAsync(new Company { Id = command.CompanyId });

        // Act
        var result = await appointmentCommandService.Handle(command);

        // Assert: Verifica que la cita fue creada correctamente
        Assert.NotNull(result);
    }

    [Fact]
    public async Task Handle_CreateAppointmentCommand_ShouldThrowExceptionWhenServiceConflictExists()
    {
        // Arrange: Configura el repositorio para devolver una cita existente que cause conflicto de horarios
        int userId = 1;
        int serviceId = 1;
        int companyId = 1;
        DateTime registerAt = DateTime.Now;
        string status = "Pending";
        DateTime reservationDate = DateTime.Today;
        string reservationStartTime = "10:00:00";
        string requirements = "Requirements";
        var command = new CreateAppointmentCommand(
            userId,
            serviceId,
            companyId,
            registerAt,
            status,
            reservationDate,
            reservationStartTime,
            requirements
        );

        mockAppointmentRepository
            .Setup(repo => repo.FindByServiceIdAndTimeAsync(command.ServiceId, command.ReservationDate, command.ReservationStartTime))
            .ReturnsAsync(new Appointment(command));

        // Act & Assert
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => appointmentCommandService.Handle(command));
        Assert.Equal("An appointment for this service at the specified time already exists.", exception.Message);
    }

    [Fact]
    public async Task Handle_CreateAppointmentCommand_ShouldThrowExceptionWhenUserConflictExists()
    {
        // Arrange: Configura el repositorio para simular un conflicto de cita para el usuario
        int userId = 1;
        int serviceId = 1;
        int companyId = 1;
        DateTime registerAt = DateTime.Now;
        string status = "Pending";
        DateTime reservationDate = DateTime.Today;
        string reservationStartTime = "10:00:00";
        string requirements = "Requirements";
        var command = new CreateAppointmentCommand(
            userId,
            serviceId,
            companyId,
            registerAt,
            status,
            reservationDate,
            reservationStartTime,
            requirements
        );

        mockAppointmentRepository
            .Setup(repo => repo.FindByUserIdAndTimeAsync(command.UserId, command.ReservationDate, command.ReservationStartTime))
            .ReturnsAsync(new Appointment(command));

        // Act & Assert
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => appointmentCommandService.Handle(command));
        Assert.Equal("The user already has an appointment at the specified time.", exception.Message);
    }
    
    
}