// Domain/Exceptions/SubscriptionNotFoundException.cs
namespace Bliss.API.SubscriptionManagement.Domain.Exceptions
{
    public class SubscriptionNotFoundException : Exception
    {
        public int SubscriptionId { get; }

        public SubscriptionNotFoundException(int subscriptionId)
            : base($"Subscription with ID {subscriptionId} was not found.")
        {
            SubscriptionId = subscriptionId;
        }
    }
}
