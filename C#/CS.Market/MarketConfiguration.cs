using System;

namespace CS.Market
{
    /// <summary>
    /// Class MarketConfiguration represents the market configuration.
    /// </summary>
    public class MarketConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MarketConfiguration"/> class.
        /// </summary>
        /// <param name="startTime">The start time.</param>
        /// <param name="initialStockPrice">The initial stock price.</param>
        /// <param name="drift">The drift.</param>
        /// <param name="volatility">The volatility.</param>
        public MarketConfiguration(DateTime? startTime = null, double initialStockPrice = 100, double drift = 0.1, double volatility = 0.2)
        {
            StartTime = startTime ?? DateTime.UtcNow;
            InitialStockPrice = initialStockPrice;
            Drift = drift;
            Volatility = volatility;
            MarketTickInterval = TimeSpan.FromSeconds(1);
        }

        /// <summary>
        /// Gets or sets the start time of market.
        /// </summary>
        /// <value>The start time.</value>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Gets or sets the initial stock price.
        /// </summary>
        /// <value>The initial stock price.</value>
        public double InitialStockPrice { get; set; }

        /// <summary>
        /// Gets or sets the drift.
        /// </summary>
        /// <value>The drift.</value>
        public double Drift { get; set; }

        /// <summary>
        /// Gets or sets the volatility.
        /// </summary>
        /// <value>The volatility.</value>
        public double Volatility { get; set; }

        /// <summary>
        /// Gets or sets the market tick interval.
        /// </summary>
        /// <value>The market tick interval.</value>
        public TimeSpan MarketTickInterval { get; set; }
    }
}