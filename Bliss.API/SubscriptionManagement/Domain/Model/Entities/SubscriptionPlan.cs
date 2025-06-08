// Domain/Model/Entities/SubscriptionPlan.cs

using Bliss.API.SubscriptionManagement.Domain.Model.Entities;

namespace Bliss.API.SubscriptionManagement.Domain.Model.Entities
{
    public class SubscriptionPlan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int DurationDays { get; set; }

        // Relación con Subscription
        public ICollection<Subscription> Subscriptions { get; set; }
    }
}