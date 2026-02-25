namespace Supermarket.PricingStrategy
{
    public interface IPricingStrategyFactory
    {
        IPricingStrategy Create(PricingRule pricingRule);
    }
}