// Application/Internal/CommandServices/ISubscriptionCommandService.cs
using Bliss.API.SubscriptionManagement.Application.Internal.CommandServices.Commands;

namespace Bliss.API.SubscriptionManagement.Application.Internal.CommandServices
{
    public interface ISubscriptionCommandService
    {
        // Crear una nueva suscripción
        Task CreateSubscriptionAsync(CreateSubscriptionCommand command);

        // Actualizar una suscripción existente
        Task UpdateSubscriptionAsync(UpdateSubscriptionCommand command);

        // Eliminar una suscripción
        Task DeleteSubscriptionAsync(int subscriptionId);
    }
}
