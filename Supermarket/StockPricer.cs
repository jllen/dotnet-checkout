using Supermarket.PricingStrategy;

namespace Supermarket
{
    public class StockPricer : IStockPricer
    {
        private readonly IEnumerable<PricingRule> pricingRules;
        private readonly IPricingStrategyFactory pricingStrategyFactory;

        public StockPricer(IEnumerable<PricingRule> pricingRules, IPricingStrategyFactory pricingStrategyFactory)
        {
            this.pricingRules = pricingRules;
            this.pricingStrategyFactory = pricingStrategyFactory;
        }

        public int Price(UnitCode unitCode, int unitCount)
        {
            var pricingRule = pricingRules.FirstOrDefault(x => x.UnitCode == unitCode);
            
            if (pricingRule == null)
            {
                throw new ArgumentException($"No pricing rule found for {unitCode}");
            }

            var pricingStrategy = pricingStrategyFactory.Create(pricingRule);

            return pricingStrategy.Price(unitCount);
        }
    }
}