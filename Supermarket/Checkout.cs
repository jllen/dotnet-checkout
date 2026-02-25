namespace Supermarket
{
    public class Checkout
    {
        private readonly List<UnitCode> items = [];

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
