using CS.Market;
using CS.Trades;
using CS.Trades.TradeTypes;

namespace CS.Pricing.PricingModels
{

    /// <summary>
    /// Class CashPricer provide the ability to price Cash.
    /// </summary>
    public class CashPricer : ITradePricer
    {

        /// <summary>
        /// Prices the specified cash.
        /// </summary>
        /// <param name="trade">The cash.</param>
        /// <param name="market">The market.</param>
        /// <param name="result">The result.</param>
        public void Price(ITrade trade, IMarketData market, IResult result)
        {
            var cash = (Cash) trade;
            result.AddValue(cash.Amount);
        }
    }
}
