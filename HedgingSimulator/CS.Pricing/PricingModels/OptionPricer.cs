using System;
using CS.Market;
using CS.Numerical;
using CS.Trades;
using CS.Trades.TradeTypes;

namespace CS.Pricing.PricingModels
{
    /// <summary>
    /// Class OptionPricer provides the ability to price Option.
    /// </summary>
    internal class OptionPricer : ITradePricer
    {
        /// <summary>
        /// Prices the specified Option trade.
        /// </summary>
        /// <param name="trade">The trade.</param>
        /// <param name="market">The market.</param>
        /// <param name="result">The result.</param>
        /// <exception cref="System.Exception">Unrecognized Option type.</exception>
        public void Price(ITrade trade, IMarketData market, IResult result)
        {
            var option = (Option) trade;

            var spot = market.StockPrice;
            var strike = option.Contract.Strike;
            var ivol = market.VolSurface.Vol(option.Contract.Maturity - market.Time, strike);

            var years = (option.Contract.Maturity - market.Time).TotalDays / 365.0;
            var d1 = (Math.Log(spot / strike) + ivol * ivol * years / 2.0) / (ivol * Math.Sqrt(years));
            var d2 = d1 - ivol * Math.Sqrt(years);
            var nD1 = NormalDistribution.CDF(d1);
            var nD2 = NormalDistribution.CDF(d2);

            double value,delta;

            switch (option.Contract.OptionType)
            {
                case OptionContract.Type.Call:
                    {
                        value = spot * nD1 - strike * nD2;
                        delta = nD1;
                        break;
                    }
                case OptionContract.Type.Put:
                    {
                        value = strike * (1.0 - nD2) - spot * (1.0 - nD1);
                        delta = -(1.0 - nD1);
                        break;
                    }
                default:
                    throw new Exception("Unrecognized Option type.");
            }

            result.AddValue(option.Notional * value);
            result.AddDelta(option.Notional * delta);
        }
    }
}
