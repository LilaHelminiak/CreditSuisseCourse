using System;
using CS.Market;

namespace CS.Trades
{
    /// <summary>
    /// Interface ITrade models generic trade.
    /// </summary>
    public interface ITrade
    {
        /// <summary>
        /// Calculate the time of trade transformation.
        /// </summary>
        /// <returns>System.Nullable&lt;DateTime&gt;.</returns>
        DateTime? TransformTime();


        /// <summary>
        /// Transforms the trade at the specified market.
        /// </summary>
        /// <param name="marketData">The market data.</param>
        /// <returns>Transformed trade.</returns>
        ITrade Transform(IMarketData marketData);
    }
}