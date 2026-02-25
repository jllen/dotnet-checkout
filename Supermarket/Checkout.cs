using Supermarket.PricingStrategy;
using System.Numerics;

namespace Supermarket
{
    public class Checkout(List<PricingRule> pricingRules)
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

            if (pricingRule.SpecialPrice == null || pricingRule.SpecialPrice.IsWhiteSpace()) 
            {
                return pricingRule.UnitPrice + unitCount;
            }

            if (pricingRule.SpecialPrice.Contains("for", StringComparison.InvariantCultureIgnoreCase)) 
            {
                var xForYElements = pricingRule.SpecialPrice.Split("for");

                var xUnits = Int32.Parse(xForYElements[0].Trim());
                var forY = Int32.Parse(xForYElements[1].Trim());

                var xForYPricingStrategy = new XForYPricingStrategy(xUnits, forY);
                return xForYPricingStrategy.Price(pricingRule.UnitPrice, unitCount);
            }

            return -1;
        }
    }
}
