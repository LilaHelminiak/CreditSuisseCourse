using System;
using System.Runtime.Serialization;

namespace CS.Market
{
    /// <summary>
    /// Class MarketData.
    /// </summary>
    [DataContract]
    public class MarketData : IMarketData 
    {
        /// <summary>
        /// Gets the time of market data.
        /// </summary>
        /// <value>The time.</value>
        [DataMember]
        public DateTime Time { get; set; }
        /// <summary>
        /// Gets the current stock price.
        /// </summary>
        /// <value>The stock price.</value>
        [DataMember]
        public double StockPrice { get; set; }
        /// <summary>
        /// Gets the volatility surface for stock.
        /// </summary>
        /// <value>The volatility surface.</value>
        [DataMember]
        public FlatVolSurface VolSurface { get; set; }
    }
}