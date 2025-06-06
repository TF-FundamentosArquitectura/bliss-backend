// Domain/Repositories/ISubscriptionRepository.cs
using Bliss.API.SubscriptionManagement.Domain.Model.Entities;

namespace Bliss.API.SubscriptionManagement.Domain.Repositories

{
    public interface ISubscriptionRepository
    {
        Task<Subscription> GetByIdAsync(int id);
        Task<IEnumerable<Subscription>> GetAllAsync();
        Task AddAsync(Subscription subscription);
        Task UpdateAsync(Subscription subscription);
        Task DeleteAsync(int id);
    }
}