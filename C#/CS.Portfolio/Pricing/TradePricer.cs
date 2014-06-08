using System;
using System.Collections.Generic;
using CS.Market;
using CS.Pricing;
using CS.Pricing.PricingModels;
using CS.Trades;
using CS.Trades.TradeTypes;

namespace CS.Portfolio.Pricing
{
    /// <summary>
    /// Class TradePricer represents the general trade pricer.
    /// </summary>
    public class TradePricer : ITradePricer
    {
        private readonly Dictionary<Type, Func<ITradePricer>> _factory = new Dictionary<Type, Func<ITradePricer>>
        {
            {typeof(Cash), () => new CashPricer() },
            {typeof(Stock), () => new StockPricer() },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="TradePricer"/> class.
        /// </summary>
        /// <param name="optionPricer">The option pricer.</param>
        public TradePricer(ExternalOptionPricer optionPricer)
        {
            _factory.Add(typeof(Option), () => optionPricer);
        }

        /// <summary>
        /// Prices the specified trade.
        /// </summary>
        /// <param name="trade">The trade.</param>
        /// <param name="market">The market.</param>
        /// <param name="result">The result.</param>
        /// <exception cref="System.Exception"></exception>
        public void Price(ITrade trade, IMarketData market, IResult result)
        {
            Func<ITradePricer> pricer;
            if (!_factory.TryGetValue(trade.GetType(), out pricer))
                throw new Exception(String.Format("Unknown trade type {0}", trade.GetType()));

            pricer().Price(trade, market, result);
        }
    }
}
