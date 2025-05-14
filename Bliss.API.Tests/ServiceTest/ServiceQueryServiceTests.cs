namespace NRG3.Bliss.API.Tests.ServiceTest;
using Moq;
using Xunit;
using NRG3.Bliss.API.ServiceManagement.Application.Internal.QueryServices;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Queries;
using NRG3.Bliss.API.ServiceManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ServiceQueryServiceTests
{
    private readonly Mock<IServiceRepository> _serviceRepositoryMock;
    private readonly ServiceQueryService _serviceQueryService;

    public ServiceQueryServiceTests()
    {
        _serviceRepositoryMock = new Mock<IServiceRepository>();
        _serviceQueryService = new ServiceQueryService(_serviceRepositoryMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldThrowArgumentException_WhenCompanyIdIsLessThanOrEqualToZero()
    {
        // [Given]: want to get all services by company ID
        int companyId = -1;
        var query = new GetAllServicesByCompanyIdQuery(companyId);

        // [When]: Company ID is 0 or less than this
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => _serviceQueryService.Handle(query));
        // [Then]: An ArgumentException should be thrown with the message "CompanyId must be greater than zero."
        Assert.Equal("CompanyId must be greater than zero.", exception.Message);
    }
}