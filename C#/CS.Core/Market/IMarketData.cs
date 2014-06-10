using System;
using System.Runtime.Serialization;

namespace CS.Market
{
    /// <summary>
    /// Interface IMarketData represents the result of evolving market.
    /// </summary>
    public interface IMarketData
    {
        /// <summary>
        /// Gets the time of market data.
        /// </summary>
        /// <value>The time.</value>
        [DataMember]
        DateTime Time { get; }

        /// <summary>
        /// Gets the current stock price.
        /// </summary>
        /// <value>The stock price.</value>
        [DataMember]
        double StockPrice { get; }

        /// <summary>
        /// Gets the volatility surface for stock.
        /// </summary>
        /// <value>The volatility surface.</value>
        [DataMember]
        FlatVolSurface VolSurface { get; }
    }
}