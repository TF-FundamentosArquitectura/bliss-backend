using NRG3.Bliss.API.ServiceManagement.Domain.Model.Entities;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Queries;

namespace NRG3.Bliss.API.ServiceManagement.Domain.Services;

public interface ICategoryQueryService
{
    /**
     * Handle get all categories query
     * <summary>
     * This method is used to handle the get all categories query.
     * </summary>
     * <param name="query">The get all categories query</param>
     * <returns>The list of categories</returns>
     */
    Task<IEnumerable<Category>> Handle(GetAllCategoriesQuery query);
    Task<Category?> Handle(GetCategoryByIdQuery query);
}