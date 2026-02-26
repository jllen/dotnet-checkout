using Supermarket.PricingStrategy;

namespace Supermarket.Test.PricingStrategy
{
    public class XForYPricingStrategyTests 
    {
        [Fact]
        public void Price_calculates_price_for_X_for_Y_pricing_rule()
        {
            var strategy = new XForYPricingStrategy(50, 3, 130);
            Assert.Equal(130, strategy.Price(3));
            Assert.Equal(180, strategy.Price(4));
            Assert.Equal(260, strategy.Price(6));
            Assert.Equal(310, strategy.Price(7));
        }
    }
}
