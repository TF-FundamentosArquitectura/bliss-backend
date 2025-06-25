// Domain/Model/Entities/Subscription.cs
namespace Bliss.API.SubscriptionManagement.Domain.Model.Entities
{
    public class Subscription
    {
        public int Id { get; set; }
        public int SubscriptionPlanId { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public string PaymentMethod { get; set; }

        // Relación con SubscriptionPlan
        public SubscriptionPlan SubscriptionPlan { get; set; }

        // Constructor con parámetros
        public Subscription(int subscriptionPlanId, int userId, DateTime startDate, DateTime endDate, string status, string paymentMethod)
        {
            SubscriptionPlanId = subscriptionPlanId;
            UserId = userId;
            StartDate = startDate;
            EndDate = endDate;
            Status = status;
            PaymentMethod = paymentMethod;
        }

        // Constructor vacío (si es necesario)
        public Subscription()
        {
        }
    }
}