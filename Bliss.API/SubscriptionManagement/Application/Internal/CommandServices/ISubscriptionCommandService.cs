// Application/Internal/CommandServices/ISubscriptionCommandService.cs
using Bliss.API.SubscriptionManagement.Domain.Model.Entities;

namespace Bliss.API.SubscriptionManagement.Application.Internal.CommandServices
{
    public interface ISubscriptionCommandService
    {
        Task CreateSubscriptionAsync(Subscription subscription);
        Task UpdateSubscriptionAsync(Subscription subscription);
        Task DeleteSubscriptionAsync(int subscriptionId);
    }
}