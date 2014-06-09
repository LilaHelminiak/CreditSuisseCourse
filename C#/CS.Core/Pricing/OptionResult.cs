using System.Runtime.Serialization;
using CS.Trades.TradeTypes;

namespace CS.Pricing
{
    /// <summary>
    /// Class OptionResult represents the result of valuation for Option Contract.
    /// </summary>
    /// <remarks>This class can be input for External Option Pricers</remarks>
    [DataContract]
    public class OptionResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OptionResult"/> class.
        /// </summary>
        /// <param name="contract">The contract.</param>
        /// <param name="result">The result.</param>
        /*public OptionResult(OptionContract contract, Result result)
        {
            Contract = contract;
            BaseResult = result;
        }*/

        /// <summary>
        /// Gets or sets the contract.
        /// </summary>
        /// <value>The contract.</value>
        [DataMember]
        public OptionContract Contract { get; set; }

        /// <summary>
        /// Gets or sets the base result.
        /// </summary>
        /// <value>The base result.</value>
        [DataMember]
        public Result BaseResult { get; set; }
    }
}