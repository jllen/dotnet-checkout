namespace Supermarket.PricingStrategy
{
    public class BuyXGetYFreePricingStrategy(int unitPrice, int buyXUnits, int getYFreeUnits) : IPricingStrategy
    {
        public int Price(int unitCount)
        {
            if (unitCount < buyXUnits)
            {
                return unitPrice * unitCount;
            }

            var ruleQualfyCount = unitCount / (buyXUnits + getYFreeUnits);
            var toPrice = unitCount - ruleQualfyCount;
            var result = toPrice * unitPrice;

            return result;
        }
    }
}
