using NRG3.Bliss.API.ServiceManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Commands;

namespace NRG3.Bliss.API.ServiceManagement.Domain.Services;

public interface IServiceCommandService
{
    /**
     * Handle create service command
     * <summary>
     * This method is used to handle the create service command.
     * </summary>
     * <param name="command">The create service command</param>
     * <returns>The service</returns>
     */
    Task<Service?> Handle(CreateServiceCommand command);
    /**
     * Handle update service command
     * <summary>
     * This method is used to handle the update service command.
     * </summary>
     * <param name="command">The update service command</param>
     * <returns>The service</returns>
     */
    Task<Service?> Handle(UpdateServiceCommand command);
    /**
     * Handle delete service command
     * <summary>
     * This method is used to handle the delete service command.
     * </summary>
     * <param name="command">The delete service command</param>
     */
    Task Handle(DeleteServiceCommand command);
}