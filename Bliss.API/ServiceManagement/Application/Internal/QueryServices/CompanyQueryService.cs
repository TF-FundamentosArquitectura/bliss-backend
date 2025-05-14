using NRG3.Bliss.API.ServiceManagement.Domain.Model.Entities;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Queries;
using NRG3.Bliss.API.ServiceManagement.Domain.Repositories;
using NRG3.Bliss.API.ServiceManagement.Domain.Services;

namespace NRG3.Bliss.API.ServiceManagement.Application.Internal.QueryServices;

public class CompanyQueryService(ICompanyRepository companyRepository) : ICompanyQueryService
{
    /// <inheritdoc />
    public async Task<IEnumerable<Company>> Handle(GetAllCompaniesQuery query)
    {
        return await companyRepository.ListAsync();
    }

    /// <inheritdoc />
    public async Task<Company?> Handle(GetCompanyByIdQuery query)
    {
        var company = await companyRepository.FindByIdAsync(query.CompanyId);
        if (company == null)
        {
            throw new InvalidOperationException("The company does not exist.");
        }
        return company;
    }
    
}