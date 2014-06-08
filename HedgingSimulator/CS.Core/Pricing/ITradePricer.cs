using CS.Market;
using CS.Trades;

namespace CS.Pricing
{

    /// <summary>
    /// Interface ITradePricer models the general trade pricer.
    /// </summary>
    public interface ITradePricer
    {
        /// <summary>
        /// Prices the specified trade.
        /// </summary>
        /// <param name="trade">The trade.</param>
        /// <param name="market">The market.</param>
        /// <param name="result">The result.</param>
        void Price(ITrade trade, IMarketData market, IResult result);
    }
}