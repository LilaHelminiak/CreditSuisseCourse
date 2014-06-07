namespace CS.Pricer
{
    public interface ITradePricer
    {
        void Price(ITrade trade, IMarketData market, IResult result);
    }
}