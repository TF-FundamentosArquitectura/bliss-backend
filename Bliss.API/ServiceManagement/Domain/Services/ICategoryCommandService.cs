using NRG3.Bliss.API.ServiceManagement.Domain.Model.Commands;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Entities;

namespace NRG3.Bliss.API.ServiceManagement.Domain.Services;

public interface ICategoryCommandService
{
    /**
     * Handle create category command
     * <summary>
     * This method is used to handle the create category command.
     * </summary>
     * <param name="command">The create category command</param>
     * <returns>The category</returns>
     */
    Task<Category?> Handle(CreateCategoryCommand command);
}