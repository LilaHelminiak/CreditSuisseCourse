using System;

namespace CS.Market
{
    /// <summary>
    /// Class MarketData.
    /// </summary>
    public class MarketData : IMarketData 
    {
        /// <summary>
        /// Gets the time of market data.
        /// </summary>
        /// <value>The time.</value>
        public DateTime Time { get; set; }
        /// <summary>
        /// Gets the current stock price.
        /// </summary>
        /// <value>The stock price.</value>
        public double StockPrice { get; set; }
        /// <summary>
        /// Gets the volatility surface for stock.
        /// </summary>
        /// <value>The volatility surface.</value>
        public IVolSurface VolSurface { get; set; }
    }
}