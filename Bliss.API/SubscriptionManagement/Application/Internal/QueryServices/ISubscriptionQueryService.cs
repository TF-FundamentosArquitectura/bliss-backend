// Application/Internal/QueryServices/ISubscriptionQueryService.cs
using Bliss.API.SubscriptionManagement.Domain.Model.Entities;

namespace Bliss.API.SubscriptionManagement.Application.Internal.QueryServices
{
    public interface ISubscriptionQueryService
    {
        Task<Subscription> GetByIdAsync(int id);
        Task<IEnumerable<Subscription>> GetAllAsync();
    }
}