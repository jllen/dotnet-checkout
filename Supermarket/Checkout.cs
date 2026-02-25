using Supermarket.PricingStrategy;

namespace Supermarket
{
    public class Checkout(List<PricingRule> pricingRules, IPricingStrategyFactory pricingStrategyFactory)
    {
        private readonly List<UnitCode> items = [];
        private List<PricingRule> pricingRules = pricingRules;

        public void Scan(UnitCode item)
        {
            items.Add(item);
        }

        public int Total()
        {
            var totalAmount = 0;

            var unitCodesGroupedBy = items.GroupBy(x => x.Value);
            foreach (var unitCodeGroup in unitCodesGroupedBy)
            {
                var unitCode = unitCodeGroup.First();
                var count = unitCodeGroup.Count();

                totalAmount += Price(unitCode, count);
            }

            return totalAmount;
        }

        private int Price(UnitCode unitCode, int unitCount)
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