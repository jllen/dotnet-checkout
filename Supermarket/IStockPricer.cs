namespace Supermarket
{
    public interface IStockPricer
    {
        int Price(UnitCode unitCode, int unitCount);
    }
}