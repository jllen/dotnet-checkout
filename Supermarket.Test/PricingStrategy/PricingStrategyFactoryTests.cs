using Supermarket.PricingStrategy;

namespace Supermarket.Test.PricingStrategy
{
    public class PricingStrategyFactoryTests
    {
        [Fact]
        public void Create_returns_XForY_pricing_strategy()
        {
            var pricingRule = new PricingRule(new UnitCode('A'), 50, "3 for 130");
            var factory = new PricingStrategyFactory();
            var strategy = factory.Create(pricingRule);

            Assert.IsType<XForYPricingStrategy>(strategy);
        }

        [Fact]
        public void Create_returns_Default_pricing_strategy()
        {
            var pricingRule = new PricingRule(new UnitCode('C'), 20);
            var factory = new PricingStrategyFactory();
            var strategy = factory.Create(pricingRule);

            Assert.IsType<DefaultPricingStrategy>(strategy);
        }

        [Fact]
        public void Create_returns_BuyXGetYFree_pricing_strategy()
        {
            var pricingRule = new PricingRule(new UnitCode('E'), 30, "Buy 2 get 1 free");
            var factory = new PricingStrategyFactory();
            var strategy = factory.Create(pricingRule);
            Assert.IsType<BuyXGetYFreePricingStrategy>(strategy);
        }

        [Fact]
        public void Create_throws_exception_for_unsupported_pricing_rule()
        {
            var pricingRule = new PricingRule(new UnitCode('F'), 2, "£3 per pound");
            var factory = new PricingStrategyFactory();
            Assert.Throws<NotSupportedException>(() => factory.Create(pricingRule));
        }
    }
}
