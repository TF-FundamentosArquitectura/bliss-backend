using NRG3.Bliss.API.ServiceManagement.Domain.Model.Commands;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Entities;
using NRG3.Bliss.API.ServiceManagement.Domain.Repositories;
using NRG3.Bliss.API.ServiceManagement.Domain.Services;
using NRG3.Bliss.API.Shared.Domain.Repositories;

namespace NRG3.Bliss.API.ServiceManagement.Application.Internal.CommandServices;

public class CategoryCommandService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
: ICategoryCommandService
{
    /// <inheritdoc />
    public async Task<Category?> Handle(CreateCategoryCommand command)
    {
        var category = new Category(command);
        await categoryRepository.AddAsync(category);
        await unitOfWork.CompleteAsync();
        return category;
    }
}