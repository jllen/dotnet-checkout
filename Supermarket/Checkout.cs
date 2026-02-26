namespace Supermarket
{
    public class Checkout(IStockPricer stockPricer)
    {
        private readonly List<UnitCode> items = [];

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

                totalAmount += stockPricer.Price(unitCode, count);
            }

            return totalAmount;
        }
    }
}