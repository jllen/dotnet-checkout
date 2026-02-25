namespace Supermarket.PricingStrategy
{
    public class XForYPricingStrategy(int unitPrice, int xUnits, int forY) : IPricingStrategy
    {
        public int Price(int unitCount)
        {
            if (unitCount < xUnits)
            {
                return unitPrice * unitCount;
            }

            var ruleQualfyCount = unitCount / xUnits;
            var remainderCount = unitCount % xUnits;

            var result = ruleQualfyCount * forY;
            result += remainderCount * unitPrice;

            return result;
        }
    }
}
