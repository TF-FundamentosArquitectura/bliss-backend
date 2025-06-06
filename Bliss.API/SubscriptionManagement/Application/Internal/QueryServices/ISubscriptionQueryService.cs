// Application/Internal/QueryServices/ISubscriptionQueryService.cs
using Bliss.API.SubscriptionManagement.Domain.Model.Entities;

namespace Bliss.API.SubscriptionManagement.Application.Internal.QueryServices
{
    public interface ISubscriptionQueryService
    {
        // Método para obtener una suscripción por su ID
        Task<Subscription> GetByIdAsync(int id);

        // Método para obtener todas las suscripciones
        Task<IEnumerable<Subscription>> GetAllAsync();

        // Método para obtener las suscripciones activas de un usuario
        Task<IEnumerable<Subscription>> GetActiveSubscriptionsByUserAsync(int userId);
        
        // Método para obtener las suscripciones por plan
        Task<IEnumerable<Subscription>> GetSubscriptionsByPlanAsync(int subscriptionPlanId);
    }
}