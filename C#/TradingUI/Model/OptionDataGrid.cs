using System;

namespace TradingUI.Model
{
    /// <summary>
    /// Class OptionData.
    /// </summary>
    public class OptionDataGrid 
    {        
        /// <summary>
        /// Gets the type of the option
        /// </summary>
        /// <value>The type</value>
        public string Type { get; set; }
        /// <summary>
        /// Gets the time of market data.
        /// </summary>
        /// <value>The time.</value>
        public DateTime Maturity { get; set; }
        /// <summary>
        /// Gets the current stock price.
        /// </summary>
        /// <value>The stock price.</value>
        public double Price { get; set; }

    }
}