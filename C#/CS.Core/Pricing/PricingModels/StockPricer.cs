using CS.Market;
using CS.Trades;
using CS.Trades.TradeTypes;

namespace CS.Pricing.PricingModels
{
    /// <summary>
    /// Class StockPricer provides that ability to price Stock.
    /// </summary>
    public class StockPricer : ITradePricer
    {
        /// <summary>
        /// Prices the specified stock trade.
        /// </summary>
        /// <param name="trade">The stock trade.</param>
        /// <param name="market">The market.</param>
        /// <param name="result">The result.</param>
        public void Price(ITrade trade, IMarketData market, IResult result)
        {
            var stock = (Stock) trade;
            result.AddValue(stock.Amount * market.StockPrice);
            result.AddDelta(stock.Amount);
        }
    }
}
