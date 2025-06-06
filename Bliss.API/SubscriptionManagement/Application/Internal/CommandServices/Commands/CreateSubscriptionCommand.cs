// Application/Internal/CommandServices/Commands/CreateSubscriptionCommand.cs
namespace Bliss.API.SubscriptionManagement.Application.Internal.CommandServices.Commands
{
    public class CreateSubscriptionCommand
    {
        public int SubscriptionId { get; set; }  
        public int SubscriptionPlanId { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public string PaymentMethod { get; set; }
    }
}
