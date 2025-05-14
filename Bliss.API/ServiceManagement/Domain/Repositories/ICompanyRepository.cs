using NRG3.Bliss.API.ServiceManagement.Domain.Model.Entities;
using NRG3.Bliss.API.Shared.Domain.Repositories;

namespace NRG3.Bliss.API.ServiceManagement.Domain.Repositories;

public interface ICompanyRepository : IBaseRepository<Company>
{
    /**
     * Find companies by company name
     * <summary>
     * This method is used to find companies by company name.
     * </summary>
     * <param name="name">The company name</param>
     * <returns>The list of companies</returns>
     */
    Task<IEnumerable<Company>> FindCompaniesByCompanyName(string name);
}