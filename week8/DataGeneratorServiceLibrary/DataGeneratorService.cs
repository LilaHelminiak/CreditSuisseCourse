using System;
using CS.Market;

namespace DataGeneratorServiceLibrary
{
    public class DataGeneratorService : IDataGeneratorService
    {
        public static MarketData calculateData = new MarketData(){ Time = DateTime.Now, StockPrice = 10000, ImpliedVolatility = 0.2 };
        private static CalculateStock clock = new CalculateStock(1, 0.1, calculateData.ImpliedVolatility, calculateData.StockPrice, 123);
        
        private void Run()
        {
            var generate = clock.RunCalculation();
            calculateData.ImpliedVolatility = generate.ImpliedVolatility;
            calculateData.Time = generate.Time;
            calculateData.StockPrice = generate.StockPrice;
        }

        public MarketData GetData()
        {
            Run();
            return new MarketData() { Time = DateTime.Now, StockPrice = 10000, ImpliedVolatility = 0.2 };
        }

    }
}
