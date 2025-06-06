// Application/Internal/CommandServices/Commands/UpdateSubscriptionCommand.cs
namespace Bliss.API.SubscriptionManagement.Application.Internal.CommandServices.Commands
{
    public class UpdateSubscriptionCommand
    {
        public int Id { get; set; }  // ID de la suscripción a actualizar
        public int SubscriptionPlanId { get; set; }
        public string Status { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime EndDate { get; set; }

        // Otros campos que pueden ser necesarios según tu modelo
    }
}
