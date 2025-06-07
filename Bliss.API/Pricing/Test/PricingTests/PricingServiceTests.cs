// Tests/PricingTests/PricingServiceTests.cs
using Bliss.API.Application.Pricing;
using Bliss.API.Domain.Pricing;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bliss.API.Infrastructure.Pricing;
using Xunit;

namespace Bliss.API.Tests.PricingTests
{
    public class PricingServiceTests
    {
        private readonly Mock<IPricingRepository> _mockRepository;
        private readonly PricingService _pricingService;

        public PricingServiceTests()
        {
            _mockRepository = new Mock<IPricingRepository>();
            _pricingService = new PricingService(_mockRepository.Object);
        }

        [Fact]
        public async Task GetAllPricingsAsync_ReturnsAllPricings()
        {
            // Arrange
            var pricingList = new List<Pricing>
            {
                new Pricing(1, 1, 100, 90, "USD", DateTime.Now, DateTime.Now.AddYears(1)),
                new Pricing(2, 2, 200, 180, "USD", DateTime.Now, DateTime.Now.AddYears(1))
            };

            _mockRepository.Setup(repo => repo.GetAllPricingsAsync()).ReturnsAsync(pricingList);

            // Act
            var result = await _pricingService.GetAllPricingsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

    }
}