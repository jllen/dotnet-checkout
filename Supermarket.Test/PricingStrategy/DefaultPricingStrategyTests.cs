using Supermarket.PricingStrategy;

namespace Supermarket.Test.PricingStrategy
{
    public class DefaultPricingStrategyTests
    {
        [Fact]
        public void TestPrice()
        {
            // Arrange
            var unitPrice = 50;
            var subject = new DefaultPricingStrategy(unitPrice);
            // Act
            var price = subject.Price(3);
            // Assert
            Assert.Equal(150, price);
        }
    }
}
