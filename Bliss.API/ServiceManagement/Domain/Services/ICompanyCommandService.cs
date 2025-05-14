using NRG3.Bliss.API.ServiceManagement.Domain.Model.Commands;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Entities;

namespace NRG3.Bliss.API.ServiceManagement.Domain.Services;

public interface ICompanyCommandService
{
    /**
     * Handle create company command
     * <summary>
     * This method is used to handle the create company command.
     * </summary>
     * <param name="command">The create company command</param>
     * <returns>The company</returns>
     */
    Task<Company?> Handle(CreateCompanyCommand command);
}