namespace Supermarket.PricingStrategy
{
    public class DefaultPricingStrategy(int unitPrice) : IPricingStrategy
    {
        public int Price(int unitCount)
        {
            return unitPrice * unitCount;
        }
    }
}