// Application/Internal/CommandServices/Commands/UpdateSubscriptionCommand.cs
namespace Bliss.API.SubscriptionManagement.Application.Internal.CommandServices.Commands
{
    public class UpdateSubscriptionCommand
    {
        public int SubscriptionId { get; set; }  // Identificador de la suscripción
        public DateTime StartDate { get; set; }  // Fecha de inicio
        public DateTime EndDate { get; set; }    // Fecha de fin
        public string Status { get; set; }       // Estado de la suscripción
        public string PaymentMethod { get; set; } // Método de pago
    }
}