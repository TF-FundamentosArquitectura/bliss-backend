// Domain/Model/Entities/Subscription.cs
namespace Bliss.API.SubscriptionManagement.Domain.Model.Entities

{
    public class Subscription
    {
        public int Id { get; private set; }
        public int SubscriptionPlanId { get; private set; }
        public int UserId { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string Status { get; private set; }
        public string PaymentMethod { get; private set; }

        // Navigation properties
        public SubscriptionPlan SubscriptionPlan { get; private set; }

        // Constructor
        public Subscription(int subscriptionPlanId, int userId, DateTime startDate, DateTime endDate, string status, string paymentMethod)
        {
            SubscriptionPlanId = subscriptionPlanId;
            UserId = userId;
            StartDate = startDate;
            EndDate = endDate;
            Status = status;
            PaymentMethod = paymentMethod;
        }

        // Métodos de dominio, por ejemplo para activar una suscripción
        public void Activate()
        {
            Status = "Active";
        }

        public void Deactivate()
        {
            Status = "Inactive";
        }
    }
}