namespace Supermarket.PricingStrategy
{
    public interface IPricingStrategy
    {
        int Price(int unitPrice, int unitCount);
    }
}
