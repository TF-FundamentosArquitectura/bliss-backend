// Infrastructure/Pricing/IPricingRepository.cs
using Bliss.API.Domain.Pricing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bliss.API.Infrastructure.Pricing
{
    public interface IPricingRepository
    {
        Task<Domain.Pricing.Pricing> GetPricingByIdAsync(int id);
        Task<IEnumerable<Domain.Pricing.Pricing>> GetAllPricingsAsync();
        Task AddPricingAsync(Domain.Pricing.Pricing pricing);
        Task UpdatePricingAsync(Domain.Pricing.Pricing pricing);
        Task DeletePricingAsync(int id);
    }
}