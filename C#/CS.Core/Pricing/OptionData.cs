using System.Collections.Generic;
using CS.Market;

namespace CS.Pricing
{
    /// <summary>
    /// Class OptionData represents the result of valuation for set of Option Contract for specific market.
    /// </summary>
    public class OptionData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OptionData"/> class.
        /// </summary>
        /// <param name="marketData">The market data.</param>
        /// <param name="optionResults">The option results.</param>
        public OptionData(MarketData marketData, OptionResult[] optionResults)
        {
            MarketData = marketData;
            OptionResults = optionResults;
        }
        public OptionData()
        { }


        /// <summary>
        /// Gets or sets the market data.
        /// </summary>
        /// <value>The market data.</value>
        public IMarketData MarketData { get; set; }


        /// <summary>
        /// Gets or sets the option results.
        /// </summary>
        /// <value>The option results.</value>
        public OptionResult[] OptionResults { get; set; }
    }
}