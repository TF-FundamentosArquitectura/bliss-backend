// Infrastructure/Pricing/PricingRepository.cs
using Bliss.API.Domain.Pricing;
using Bliss.API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bliss.API.Infrastructure.Pricing
{
    public class PricingRepository : IPricingRepository
    {
        private readonly ApplicationDbContext _context;

        public PricingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Pricing.Pricing> GetPricingByIdAsync(int id)
        {
            return await _context.Pricings
                .Include<Domain.Pricing.Pricing, object>(p => p.Service)
                .Include(p => p.Specialist)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Domain.Pricing.Pricing>> GetAllPricingsAsync()
        {
            return await _context.Pricings
                .Include(p => p.Service)
                .Include<Domain.Pricing.Pricing, object>(p => p.Specialist)
                .ToListAsync();
        }

        public async Task AddPricingAsync(Domain.Pricing.Pricing pricing)
        {
            _context.Pricings.Add(pricing);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePricingAsync(Domain.Pricing.Pricing pricing)
        {
            _context.Pricings.Update(pricing);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePricingAsync(int id)
        {
            var pricing = await _context.Pricings.FindAsync(id);
            if (pricing != null)
            {
                _context.Pricings.Remove(pricing);
                await _context.SaveChangesAsync();
            }
        }
    }
}