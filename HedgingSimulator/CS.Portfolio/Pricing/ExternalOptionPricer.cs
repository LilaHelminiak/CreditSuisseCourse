using System.Linq;
using CS.Market;
using CS.Pricing;
using CS.Trades;
using CS.Trades.TradeTypes;

namespace CS.Portfolio.Pricing
{
    /// <summary>
    /// Class ExternalOptionPricer provides the ability to price Option base on externally calculated OptionContract price.
    /// </summary>
    public class ExternalOptionPricer : ITradePricer
    {
        private readonly OptionResult[] _optionResults;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExternalOptionPricer"/> class.
        /// </summary>
        /// <param name="optionResults">The option results.</param>
        public ExternalOptionPricer(OptionResult[] optionResults)
        {
            _optionResults = optionResults;
        }

        /// <summary>
        /// Prices the Option trade.
        /// </summary>
        /// <param name="trade">The trade.</param>
        /// <param name="market">The market.</param>
        /// <param name="result">The result.</param>
        public void Price(ITrade trade, IMarketData market, IResult result)
        {
            var option = (Option) trade;
            
            var optionResult = _optionResults.FirstOrDefault(x => x.Contract.Equals(option.Contract));
            if(optionResult != null)
            {
                result.AddDelta(optionResult.BaseResult.Delta * (option.Notional / optionResult.Contract.BaseNotional));
                result.AddValue(optionResult.BaseResult.Value * (option.Notional / optionResult.Contract.BaseNotional));
            }
        }
    }
}