// Application/Pricing/PricingService.cs

using Bliss.API.Infrastructure.Pricing;

namespace Bliss.API.Application.Pricing
{
    public class PricingService
    {
        private readonly IPricingRepository _pricingRepository;

        public PricingService(IPricingRepository pricingRepository)
        {
            _pricingRepository = pricingRepository;
        }

        public async Task<IEnumerable<Domain.Pricing.Pricing>> GetAllPricingsAsync()
        {
            return (IEnumerable<Domain.Pricing.Pricing>)await _pricingRepository.GetAllPricingsAsync();
        }

        public async Task<Domain.Pricing.Pricing> GetPricingByIdAsync(int id)
        {
            return await _pricingRepository.GetPricingByIdAsync(id);
        }

        public async Task AddPricingAsync(Domain.Pricing.Pricing pricing)
        {
            await _pricingRepository.AddPricingAsync(pricing);
        }

        public async Task UpdatePricingAsync(Domain.Pricing.Pricing pricing)
        {
            await _pricingRepository.UpdatePricingAsync(pricing);
        }

        public async Task DeletePricingAsync(int id)
        {
            await _pricingRepository.DeletePricingAsync(id);
        }
    }
}