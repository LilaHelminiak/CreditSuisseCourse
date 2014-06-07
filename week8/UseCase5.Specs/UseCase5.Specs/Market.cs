using System;
using CS.Market;

namespace UseCase5.Specs
{
    class Market: IMarketData
    {
        public DateTime Time { get; set; }
        public double StockPrice { get; set; }
        public double ImpliedVolatility { get; set; }

        public Market()
        {
            Time = DateTime.MinValue;
            StockPrice = 0;
        }

        public bool Update(DateTime newTime, double newPrice)
        {
            Time = newTime;
            StockPrice = newPrice;
            return true;
        }
    }
}
