using System;
using CS.Numerical;

namespace CS.Market
{
    /// <summary>
    /// Class LogNormalMarket models standard normally distributed market.
    /// </summary>
    public class LogNormalMarket : IMarketData, IEvolve
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LogNormalMarket"/> class.
        /// </summary>
        /// <param name="marketConfiguration">The market configuration.</param>
        public LogNormalMarket(MarketConfiguration marketConfiguration)
        {
            _drift = marketConfiguration.Drift;
            _volatility = marketConfiguration.Volatility;
            _random = new Random();
            Time = marketConfiguration.StartTime;
            StockPrice = marketConfiguration.InitialStockPrice;
            VolSurface = new FlatVolSurface(marketConfiguration.Volatility);
        }

        /// <summary>
        /// Gets the time of market data.
        /// </summary>
        /// <value>The time.</value>
        public DateTime Time { get; private set; }


        /// <summary>
        /// Gets the current stock price.
        /// </summary>
        /// <value>The stock price.</value>
        public double StockPrice { get; private set; }


        /// <summary>
        /// Gets the volatility surface for stock.
        /// </summary>
        /// <value>The volatility surface.</value>
        public FlatVolSurface VolSurface { get; private set; }

        /// <summary>
        /// Evolves the specified time.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <exception cref="System.Exception">This function should only be used to evolve forward in time.</exception>
        public void Evolve(TimeSpan time)
        {
            if (time <= TimeSpan.Zero)
                throw new Exception("This function should only be used to evolve forward in time.");

            // Obtain a standard normally distributed random variable
            var randUniform = _random.NextDouble(); // Uniformly distributed on [0,1]
            var randStdNormal = NormalDistribution.InverseCDF(randUniform); // Transform to standard normal N(0,1)

            var years = time.TotalDays / 365.0;
            StockPrice *= Math.Exp((_drift - 0.5 * _volatility * _volatility) * years + _volatility * Math.Sqrt(years) * randStdNormal);
            Time = Time + time; 
        }

        private readonly double _drift;
        private readonly double _volatility;
        private readonly Random _random;
    }
}