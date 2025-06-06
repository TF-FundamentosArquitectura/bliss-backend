// Application/Internal/CommandServices/CommandHandlers/CreateSubscriptionCommandHandler.cs
using Bliss.API.SubscriptionManagement.Application.Internal.CommandServices.Commands;
using Bliss.API.SubscriptionManagement.Domain.Model.Entities;
using Bliss.API.SubscriptionManagement.Domain.Repositories;

namespace Bliss.API.SubscriptionManagement.Application.Internal.CommandServices.CommandHandlers
{
    public class CreateSubscriptionCommandHandler
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public CreateSubscriptionCommandHandler(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task HandleAsync(CreateSubscriptionCommand command)
        {
            // Validar y crear la nueva suscripción
            var subscription = new Subscription(
                command.SubscriptionPlanId,
                command.UserId,
                command.StartDate,
                command.EndDate,
                command.Status,
                command.PaymentMethod
            );

            // Guardar la suscripción en el repositorio
            await _subscriptionRepository.AddAsync(subscription);
        }
    }
}