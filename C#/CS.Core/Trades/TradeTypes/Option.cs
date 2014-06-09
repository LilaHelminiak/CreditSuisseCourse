using System;
using System.Runtime.Serialization;
using CS.Market;

namespace CS.Trades.TradeTypes
{
    /// <summary>
    /// Class Option models the Option trade.
    /// </summary>
    public class Option : ITrade
    {
        public OptionContract Contract { get;  set; }
        public double Notional { get;  set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Option"/> class.
        /// </summary>
        /// <param name="contract">The contract.</param>
        /// <param name="notional">The notional.</param>
        public Option(OptionContract contract, double notional)
        {
            Contract = contract;
            Notional = notional;
        }

        /// <summary>
        /// Transforms the option to Cash at Maturity.
        /// </summary>
        /// <param name="marketData">The market data.</param>
        /// <returns>Transformed trade.</returns>
        public ITrade Transform(IMarketData marketData)
        {
            if (marketData.Time == Contract.Maturity)
            {
                var payoff = Notional * Math.Max((marketData.StockPrice - Contract.Strike) * (Contract.OptionType == OptionContract.Type.Call ? 1 : -1), 0);
                return new Cash(payoff);
            }
            return this;
        }

        /// <summary>
        /// Maturity at witch Option transforms to Cash.
        /// </summary>
        /// <returns>System.Nullable&lt;DateTime&gt;.</returns>
        public DateTime? TransformTime()
        {
            return Contract.Maturity;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return string.Format("{0:yy-MMM} {1:##.###} {2}", Contract.Maturity, Contract.Strike, Contract.OptionType);
        }
    }

    /// <summary>
    /// Class OptionContract models the contract for Option.
    /// </summary>
    [DataContract]
    public sealed class OptionContract
    {
        /// <summary>
        /// Option Type
        /// </summary>
        public enum Type
        {
            Put, Call
        }

        /// <summary>
        /// Gets the type of the option.
        /// </summary>
        /// <value>The type of the option.</value>
        [DataMember]
        public Type OptionType { get; private set; }


        /// <summary>
        /// Gets the base notional.
        /// </summary>
        /// <value>The base notional.</value>
        [DataMember]
        public double BaseNotional { get; private set; }


        /// <summary>
        /// Gets the strike.
        /// </summary>
        /// <value>The strike.</value>
        [DataMember]
        public double Strike { get; private set; }


        /// <summary>
        /// Gets the maturity.
        /// </summary>
        /// <value>The maturity.</value>
        [DataMember]
        public DateTime Maturity { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OptionContract"/> class.
        /// </summary>
        /// <param name="optionType">Type of the option.</param>
        /// <param name="baseNotional">The base notional.</param>
        /// <param name="strike">The strike.</param>
        /// <param name="maturity">The maturity.</param>
        /*public OptionContract(Type optionType, double baseNotional, double strike, DateTime maturity)
        {
            OptionType = optionType;
            BaseNotional = baseNotional;
            Strike = strike;
            Maturity = maturity;
        }*/

        /// <summary>
        /// Equalses the specified other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool Equals(OptionContract other)
        {
            return OptionType == other.OptionType && BaseNotional.Equals(other.BaseNotional) && Strike.Equals(other.Strike) && Maturity.Equals(other.Maturity);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is OptionContract && Equals((OptionContract) obj);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int) OptionType;
                hashCode = (hashCode*397) ^ BaseNotional.GetHashCode();
                hashCode = (hashCode*397) ^ Strike.GetHashCode();
                hashCode = (hashCode*397) ^ Maturity.GetHashCode();
                return hashCode;
            }
        }
    }
}
