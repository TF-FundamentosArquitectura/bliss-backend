// Application/Internal/CommandServices/CommandHandlers/DeleteSubscriptionCommandHandler.cs
using Bliss.API.SubscriptionManagement.Domain.Repositories;

namespace Bliss.API.SubscriptionManagement.Application.Internal.CommandServices.CommandHandlers
{
    public class DeleteSubscriptionCommandHandler
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public DeleteSubscriptionCommandHandler(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task HandleAsync(int subscriptionId)
        {
            // Buscar la suscripción por ID
            var subscription = await _subscriptionRepository.GetByIdAsync(subscriptionId);
            if (subscription == null)
            {
                throw new Exception("Subscription not found.");
            }

            // Eliminar la suscripción
            await _subscriptionRepository.DeleteAsync(subscriptionId);
        }
    }
}