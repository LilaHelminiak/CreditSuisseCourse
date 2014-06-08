namespace CS.Pricing
{

    /// <summary>
    /// Interface IResult models the pricing result of trade.
    /// </summary>
    public interface IResult
    {

        /// <summary>
        /// Gets the value of trade.
        /// </summary>
        /// <value>The value.</value>
        double Value { get; }


        /// <summary>
        /// Gets the delta.
        /// </summary>
        /// <value>The delta.</value>
        double Delta { get; }


        /// <summary>
        /// Adds to the value.
        /// </summary>
        /// <param name="value">The value.</param>
        void AddValue(double value);


        /// <summary>
        /// Adds to the delta.
        /// </summary>
        /// <param name="delta">The delta.</param>
        void AddDelta(double delta);
    }
}
