using System;
using CS.Market;

namespace CS.Trades.TradeTypes
{
    /// <summary>
    /// Class Cash models Cash trade.
    /// </summary>
    public class Cash : ITrade
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Cash"/> class.
        /// </summary>
        /// <param name="amount">The amount.</param>
        public Cash(double amount) 
        { 
            Amount = amount; 
        }

        /// <summary>
        /// Gets the amount.
        /// </summary>
        /// <value>The amount.</value>
        public double Amount { get; private set; }

        /// <summary>
        /// Cash it not transformable.
        /// </summary>
        /// <param name="marketData">The market data.</param>
        /// <returns>Transformed trade.</returns>
        public ITrade Transform(IMarketData marketData)
        {
            return this;
        }

        /// <summary>
        /// Cash it not transformable.
        /// </summary>
        /// <returns>System.Nullable&lt;DateTime&gt;.</returns>
        public DateTime? TransformTime()
        {
            return null;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return "Cash";
        }
    }
}
