// Application/Internal/CommandServices/SubscriptionCommandService.cs
using Bliss.API.SubscriptionManagement.Domain.Repositories;
using Bliss.API.SubscriptionManagement.Domain.Model.Entities;

namespace Bliss.API.SubscriptionManagement.Application.Internal.CommandServices
{
    public class SubscriptionCommandService : ISubscriptionCommandService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public SubscriptionCommandService(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task CreateSubscriptionAsync(Subscription subscription)
        {
            await _subscriptionRepository.AddAsync(subscription);
        }

        public async Task UpdateSubscriptionAsync(Subscription subscription)
        {
            await _subscriptionRepository.UpdateAsync(subscription);
        }

        public async Task DeleteSubscriptionAsync(int subscriptionId)
        {
            await _subscriptionRepository.DeleteAsync(subscriptionId);
        }
    }
}