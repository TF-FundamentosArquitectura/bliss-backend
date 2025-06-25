// Application/Internal/QueryServices/SubscriptionQueryService.cs
using Bliss.API.SubscriptionManagement.Domain.Repositories;
using Bliss.API.SubscriptionManagement.Domain.Model.Entities;

namespace Bliss.API.SubscriptionManagement.Application.Internal.QueryServices
{
    public class SubscriptionQueryService : ISubscriptionQueryService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public SubscriptionQueryService(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<Subscription> GetByIdAsync(int id)
        {
            return await _subscriptionRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Subscription>> GetAllAsync()
        {
            return await _subscriptionRepository.GetAllAsync();
        }
    }
}