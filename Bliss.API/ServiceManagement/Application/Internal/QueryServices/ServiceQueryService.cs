using NRG3.Bliss.API.ServiceManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Queries;
using NRG3.Bliss.API.ServiceManagement.Domain.Repositories;
using NRG3.Bliss.API.ServiceManagement.Domain.Services;

namespace NRG3.Bliss.API.ServiceManagement.Application.Internal.QueryServices;

public class ServiceQueryService(IServiceRepository serviceRepository) : IServiceQueryService
{
    /// <inheritdoc />
    public async Task<Service?> Handle(GetServiceByIdQuery query)
    {
        return await serviceRepository.FindServiceById(query.ServiceId);
    }
    
    /// <inheritdoc />
    public async Task<IEnumerable<Service>> Handle(GetAllServicesQuery query)
    {
        return await serviceRepository.FindAllServices();
    }
    
    /// <inheritdoc />
    public async Task<IEnumerable<Service>> Handle(GetAllServicesByCompanyIdQuery query)
    {
        if (query.CompanyId <= 0)
        {
            throw new ArgumentException("CompanyId must be greater than zero.");
        }
        return await serviceRepository.FindServicesByCompanyIdAsync(query.CompanyId);
    }
}