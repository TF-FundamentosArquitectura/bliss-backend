// Domain/Model/Entities/SubscriptionPlan.cs
namespace Bliss.API.SubscriptionManagement.Domain.Model.Entities
{
    public class SubscriptionPlan
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int DurationDays { get; private set; }

        // Constructor
        public SubscriptionPlan(string name, string description, decimal price, int durationDays)
        {
            Name = name;
            Description = description;
            Price = price;
            DurationDays = durationDays;
        }
    }
}