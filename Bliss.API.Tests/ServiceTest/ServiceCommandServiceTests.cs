
using Moq;
using NRG3.Bliss.API.ServiceManagement.Application.Internal.CommandServices;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Commands;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Entities;
using NRG3.Bliss.API.ServiceManagement.Domain.Repositories;
using NRG3.Bliss.API.Shared.Domain.Repositories;

namespace NRG3.Bliss.API.Tests.ServiceTest
{
    public class ServiceCommandServiceTests
    {
       private readonly Mock<IServiceRepository> _serviceRepositoryMock;
       private readonly Mock<ICategoryRepository> _categoryRepositoryMock;
       private readonly Mock<ICompanyRepository> _companyRepositoryMock;
       private readonly Mock<IUnitOfWork> _unitOfWorkMock;
       private readonly ServiceCommandService _serviceCommandService;

        public ServiceCommandServiceTests()
        {
            _serviceRepositoryMock = new Mock<IServiceRepository>();
            _categoryRepositoryMock = new Mock<ICategoryRepository>();
            _companyRepositoryMock = new Mock<ICompanyRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _serviceCommandService = new ServiceCommandService(
                _serviceRepositoryMock.Object,
                _categoryRepositoryMock.Object, 
                _companyRepositoryMock.Object,
                _unitOfWorkMock.Object);
        }
        // [Scenario]: Attempting to create a service with a duplicate name
        [Fact]
        public async Task Handle_WhenServiceNameIsNotUnique()
        {
            // [Given]: that a new service is to be created
            var commad = new CreateServiceCommand(
                1,
                1,
                "DuplicateServiceName",
                "DescriptionService",
                100,
                30,
                "ImageUrl"
                );
            // [When]: service data is passed with an existing name for the company and category.
            _serviceRepositoryMock.Setup(repo =>
                repo.ServiceNameExistsForCompanyAndCategoryAsync(commad.CompanyId, commad.CategoryId, commad.ServiceName)).ReturnsAsync(true);
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => _serviceCommandService.Handle(commad));
            // [Then]: An InvalidOperationException is thrown with the message "The service name already exists for the company and category."
            Assert.Equal("The service name already exists for the company and category.", exception.Message);
        }
        [Fact]
        public async Task Handle_ShouldCreateService_WhenServiceNameIsUnique()
        {
            var command = new CreateServiceCommand(
                1,
                1,
                "Unique Service",
                "Description the service",
                100,
                30,
                "ImageUrl");
            var category = new Category { Id = 1,Name = "Category1"};
            var company = new Company { Id = 1,Name = "Company1"};
            _serviceRepositoryMock.Setup(repo =>
                repo.ServiceNameExistsForCompanyAndCategoryAsync(command.CompanyId, command.CategoryId,
                    command.ServiceName)).ReturnsAsync(false);
            _categoryRepositoryMock.Setup(repo => repo.FindByIdAsync(command.CategoryId)).ReturnsAsync(category);
            _companyRepositoryMock.Setup(repo => repo.FindByIdAsync(command.CompanyId)).ReturnsAsync(company);
            _serviceRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Service>())).Returns(Task.CompletedTask);
            _unitOfWorkMock.Setup(uow => uow.CompleteAsync()).Returns(Task.CompletedTask);

            var result = await _serviceCommandService.Handle(command);
            Assert.NotNull(result);
            Assert.Equal(command.CompanyId,result.CompanyId);
            Assert.Equal(command.CategoryId,result.CategoryId);
            Assert.Equal(command.ServiceName,result.Name);
            Assert.Equal(command.Description,result.Description);
            Assert.Equal(command.Price,result.Price);
            Assert.Equal(command.Duration, result.Duration);
        }


        


    }
}

