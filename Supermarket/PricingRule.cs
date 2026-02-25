namespace Supermarket
{
    public class PricingRule
    {
        public PricingRule(UnitCode unitCode, int unitPrice)
        {
            UnitCode = unitCode;
            UnitPrice = unitPrice;
        }

        public PricingRule(UnitCode unitCode, int unitPrice, string specialPrice)
        {
            UnitCode = unitCode;
            UnitPrice = unitPrice;
            SpecialPrice = specialPrice;
        }

        public UnitCode UnitCode { get; }
        public int UnitPrice { get; }
        public string SpecialPrice { get; } = string.Empty;
    }
}
