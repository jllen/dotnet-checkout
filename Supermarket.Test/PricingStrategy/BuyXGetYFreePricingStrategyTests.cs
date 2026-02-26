using Supermarket.PricingStrategy;

namespace Supermarket.Test.PricingStrategy
{
    public class BuyXGetYFreePricingStrategyTests
    {
        [Fact]
        public void Price_calculates_correctly_for_buy_x_get_y_free()
        {
            var strategy = new BuyXGetYFreePricingStrategy(50, 2, 1);

            Assert.Equal(100, strategy.Price(2)); // Pay for 2
            Assert.Equal(100, strategy.Price(3)); // Pay for 2, get 1 free
            Assert.Equal(150, strategy.Price(4)); // Pay for 3, get 1 free
            Assert.Equal(200, strategy.Price(5)); // Pay for 4, get 1 free
            Assert.Equal(200, strategy.Price(6)); // Pay for 4, get 2 free
        }
    }
}
