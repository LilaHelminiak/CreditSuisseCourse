using System;

namespace CS.Market
{
    /// <summary>
    /// Interface IEvolve models the entity that has ability to evolve with time.
    /// </summary>
    public interface IEvolve
    {
        /// <summary>
        /// Evolves at the specified time offset.
        /// </summary>
        /// <param name="offset">The offset.</param>
        void Evolve(TimeSpan offset);
    }
}