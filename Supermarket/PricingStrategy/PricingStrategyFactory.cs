namespace Supermarket.PricingStrategy
{
    public class PricingStrategyFactory : IPricingStrategyFactory
    {
        public IPricingStrategy Create(PricingRule pricingRule)
        {
            if (pricingRule.SpecialPrice == null || pricingRule.SpecialPrice.IsWhiteSpace())
            {
                return new DefaultPricingStrategy(pricingRule.UnitPrice);
            }

            if (pricingRule.SpecialPrice.Contains("for", StringComparison.InvariantCultureIgnoreCase))
            {
                var xForYElements = pricingRule.SpecialPrice.Split("for");

                var xUnits = Int32.Parse(xForYElements[0].Trim());
                var forY = Int32.Parse(xForYElements[1].Trim());

                return new XForYPricingStrategy(pricingRule.UnitPrice, xUnits, forY);
            }

            if(pricingRule.SpecialPrice.StartsWith("Buy", StringComparison.InvariantCultureIgnoreCase))
            {
                var buyXGetYFreeElements = pricingRule.SpecialPrice.Split("get");
                var buyXUnits = Int32.Parse(buyXGetYFreeElements[0].Replace("Buy", string.Empty).Trim());
                var getYFreeUnits = Int32.Parse(buyXGetYFreeElements[1].Replace("free", string.Empty).Trim());

                return new BuyXGetYFreePricingStrategy(pricingRule.UnitPrice, buyXUnits, getYFreeUnits);
            }

            throw new NotSupportedException($"Unsupported pricing rule {pricingRule.SpecialPrice}");
        }
    }

}