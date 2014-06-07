using System;

namespace CS.Market
{
    public interface IMarketData
    {
        DateTime Time { get; }
        double StockPrice { get; }
        double ImpliedVolatility { get; }
    }
}
