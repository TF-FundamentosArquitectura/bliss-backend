// Application/Internal/QueryServices/QueryHandlers/GetSubscriptionByIdQueryHandler.cs
using Bliss.API.SubscriptionManagement.Application.Internal.QueryServices.Queries;
using Bliss.API.SubscriptionManagement.Domain.Model.Entities;
using Bliss.API.SubscriptionManagement.Domain.Repositories;

namespace Bliss.API.SubscriptionManagement.Application.Internal.QueryServices.QueryHandlers
{
    public class GetSubscriptionByIdQueryHandler
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public GetSubscriptionByIdQueryHandler(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<Subscription> HandleAsync(GetSubscriptionByIdQuery query)
        {
            var subscription = await _subscriptionRepository.GetByIdAsync(query.Id);
            if (subscription == null)
            {
                throw new Exception("Subscription no encontrada.");
            }
            return subscription;
        }
    }
}
