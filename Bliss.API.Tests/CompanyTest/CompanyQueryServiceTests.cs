namespace NRG3.Bliss.API.Tests;
using Moq;
using NRG3.Bliss.API.ServiceManagement.Application.Internal.QueryServices;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Entities;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Queries;
using NRG3.Bliss.API.ServiceManagement.Domain.Repositories;
using Xunit;
//Unit tests for CompanyQueryService
public class CompanyQueryServiceTests
{
    private readonly Mock<ICompanyRepository> _companyRepositoryMock;
    private readonly CompanyQueryService _companyQueryService;

    public CompanyQueryServiceTests()
    {
        _companyRepositoryMock = new Mock<ICompanyRepository>();
        _companyQueryService = new CompanyQueryService(_companyRepositoryMock.Object);
    }

    [Fact]
    public async Task HandleShouldThrowExceptionWhenCompanyDoesNotExist()
    {
        //Pass a company ID that does not exist
        var query = new GetCompanyByIdQuery(1);
        _companyRepositoryMock.Setup(repo => repo.FindByIdAsync(query.CompanyId))
            .ReturnsAsync((Company?)null);//Return null when the company does not exist

        //if the company does not exist, an InvalidOperationException should be thrown with the message "The company does not exist."
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => _companyQueryService.Handle(query));
        Assert.Equal("The company does not exist.", exception.Message);
    }

    [Fact]
    public async Task HandleShouldReturnCompanyWhenCompanyExists()
    {
        // Pass a company ID
        var query = new GetCompanyByIdQuery(1);
        var company = new Company { Id = 1, Name = "Test Company" };//Pass a company ID that exists
        _companyRepositoryMock.Setup(repo => repo.FindByIdAsync(query.CompanyId))
            .ReturnsAsync(company);

        // that company should be returned
        var result = await _companyQueryService.Handle(query);

        // Check that the company returned is the same as the one passed in the setup 
        Assert.NotNull(result);
        Assert.Equal(company.Id, result.Id);
        Assert.Equal(company.Name, result.Name);
    }
}