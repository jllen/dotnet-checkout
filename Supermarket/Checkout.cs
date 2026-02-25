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
            throw new NotImplementedException();
        }
    }
}
