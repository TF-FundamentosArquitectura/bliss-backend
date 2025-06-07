// Controllers/PricingController.cs
using Bliss.API.Application.Pricing;
using Bliss.API.Domain.Pricing;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bliss.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingController : ControllerBase
    {
        private readonly PricingService _pricingService;

        public PricingController(PricingService pricingService)
        {
            _pricingService = pricingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPricing()
        {
            var pricings = await _pricingService.GetAllPricingsAsync();
            return Ok(pricings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPricing(int id)
        {
            var pricing = await _pricingService.GetPricingByIdAsync(id);
            if (pricing == null)
            {
                return NotFound();
            }
            return Ok(pricing);
        }

        [HttpPost]
        public async Task<IActionResult> AddPricing([FromBody] Pricing pricing)
        {
            await _pricingService.AddPricingAsync(pricing);
            return CreatedAtAction(nameof(GetPricing), new { id = pricing.Id }, pricing);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePricing(int id, [FromBody] Pricing pricing)
        {
            if (id != pricing.Id)
            {
                return BadRequest();
            }

            await _pricingService.UpdatePricingAsync(pricing);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePricing(int id)
        {
            await _pricingService.DeletePricingAsync(id);
            return NoContent();
        }
    }
}