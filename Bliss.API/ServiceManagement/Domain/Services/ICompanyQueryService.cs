using NRG3.Bliss.API.ServiceManagement.Domain.Model.Entities;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Queries;

namespace NRG3.Bliss.API.ServiceManagement.Domain.Services;

public interface ICompanyQueryService
{
    /**
     * Handle get all companies query
     * <summary>
     * This method is used to handle the get all companies query.
     * </summary>
     * <param name="query">The get all companies query</param>
     * <returns>The list of companies</returns>
     */
    Task<IEnumerable<Company>> Handle(GetAllCompaniesQuery query);
    /**
     * Handle get company by id query
     * <summary>
     * This method is used to handle the get company by id query.
     * </summary>
     * <param name="query">The get company by id query</param>
     * <returns>The company</returns>
     */
    Task<Company?> Handle(GetCompanyByIdQuery query);
}