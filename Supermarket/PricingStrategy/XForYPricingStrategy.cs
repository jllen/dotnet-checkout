namespace Supermarket.PricingStrategy
{
    public class XForYPricingStrategy(int xUnits, int forY) : IPricingStrategy
    {
        public int Price(int unitPrice, int unitCount)
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
