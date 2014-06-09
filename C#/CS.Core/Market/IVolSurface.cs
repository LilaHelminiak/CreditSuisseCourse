using System;
using System.Runtime.Serialization;

namespace CS.Market
{
    /// <summary>
    /// Interface IVolSurface models the volatility surface
    /// </summary>
    public interface IVolSurface
    {
        /// <summary>
        /// Calculate volatility at specified time.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <param name="strike">The strike.</param>
        /// <returns>System.Double.</returns>
        /// <remarks>Behavior should only be supported for time > TimeSpan.Zero</remarks>
        double Vol(TimeSpan time, double strike);
    }
}