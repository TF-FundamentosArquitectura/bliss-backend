using Moq;
using NRG3.Bliss.API.ServiceManagement.Application.Internal.CommandServices;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Commands;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Entities;
using NRG3.Bliss.API.ServiceManagement.Domain.Repositories;
using NRG3.Bliss.API.Shared.Domain.Repositories;
using Xunit;
// integrations tests are used to test the interaction between different parts of the system, in this case the interaction between the CompanyCommandService class and the CompanyRepository class
namespace NRG3.Bliss.API.Tests
{
    public class CompanyCommandServiceTests
    {
        private readonly Mock<ICompanyRepository> _companyRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly  CompanyCommandService _companyCommandService; 
        
        public CompanyCommandServiceTests()
        {
            _companyRepositoryMock = new Mock<ICompanyRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _companyCommandService = new CompanyCommandService(_companyRepositoryMock.Object, _unitOfWorkMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldThrowException_WhenCompanyNameExists()
        {
            // Arrange
            // A new instance of the CreateCompanyCommand class is being created with the parameters of the existing company
            //TS001
            // [Given] that a new company is being created
            var command = new CreateCompanyCommand(
                "ExistingCompany",
                "123456789",
                "compan1@gmail.com",
                "www.company1.com",
                "123456789",
                "Company1Description"
            );//[AND] a company with the same name as the company being created already exists in the database
            _companyRepositoryMock.Setup(repo => repo.FindCompaniesByCompanyName(command.Name))
                .ReturnsAsync(new List<Company> { new Company { Name = "ExistingCompany" } });//[WHEN] the new company is added

            // Act & Assert
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => _companyCommandService.Handle(command));// se esta verificando que al llamar al metodo Handle de la clase CompanyCommandService con el comando de la empresa existente se lance una excepcion de tipo InvalidOperationException
            Assert.Equal("The company name already exists.", exception.Message);//[THEN] an exception is sent that says "The company name already exists.".
        }

        [Fact]
        public async Task Handle_ShouldCreateCompany_WhenCompanyNameDoesNotExist()
        {
          
            var command = new CreateCompanyCommand(
                "NewCompany",
                "123456789",
                "compan1@gmail.com",
                "www.company1.com",
                "123456789",
                "Company1Description"
            );
            _companyRepositoryMock.Setup(repo => repo.FindCompaniesByCompanyName(command.Name))
                .ReturnsAsync(new List<Company>());
            _companyRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Company>())).Returns(Task.CompletedTask);
            _unitOfWorkMock.Setup(uow => uow.CompleteAsync()).Returns(Task.CompletedTask);

           
            var result = await _companyCommandService.Handle(command);

            
            Assert.NotNull(result);
            Assert.Equal(command.Name, result.Name);
            _companyRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Company>()), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.CompleteAsync(), Times.Once);
        }
    
    }
}

