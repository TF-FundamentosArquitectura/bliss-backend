// Application/Internal/CommandServices/CommandHandlers/UpdateSubscriptionCommandHandler.cs
using Bliss.API.SubscriptionManagement.Application.Internal.CommandServices.Commands;
using Bliss.API.SubscriptionManagement.Domain.Model.Entities;
using Bliss.API.SubscriptionManagement.Domain.Repositories;

namespace Bliss.API.SubscriptionManagement.Application.Internal.CommandServices.CommandHandlers
{
    public class UpdateSubscriptionCommandHandler
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public UpdateSubscriptionCommandHandler(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task HandleAsync(UpdateSubscriptionCommand command)
        {
            // Buscar la suscripción existente
            var subscription = await _subscriptionRepository.GetByIdAsync(command.SubscriptionId);
            if (subscription == null)
            {
                throw new Exception("Subscription not found.");
            }

            // Actualizar la suscripción con los nuevos datos
            subscription.StartDate = command.StartDate;
            subscription.EndDate = command.EndDate;
            subscription.Status = command.Status;
            subscription.PaymentMethod = command.PaymentMethod;

            // Guardar la suscripción actualizada
            await _subscriptionRepository.UpdateAsync(subscription);
        }
    }
}