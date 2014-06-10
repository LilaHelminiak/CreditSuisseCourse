using System;
using System.Runtime.Serialization;

namespace CS.Market
{
    /// <summary>
    /// Class FlatVolSurface models the flat volatility surface.
    /// </summary>
    [DataContract]
    public class FlatVolSurface : IVolSurface
    {
        public FlatVolSurface(double vol)
        {
            Volatility = vol;
        }


        /// <summary>
        /// Calculate volatility at specified time.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <param name="strike">The strike.</param>
        /// <returns>System.Double.</returns>
        /// <exception cref="System.Exception">Implied volatility can only be queried for future times.</exception>
        public double Vol(TimeSpan time, double strike)
        {
            if (time < TimeSpan.Zero)
                throw new Exception("Implied volatility can only be queried for future times.");
            return Volatility;
        }
        [DataMember]
        public double Volatility { get; set; }
    }
}
