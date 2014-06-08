namespace CS.Pricing
{
    /// <summary>
    /// Class Result models the pricing result of trade.
    /// </summary>
    public class Result : IResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Result"/> class.
        /// </summary>
        public Result()
        {
            Value = 0.0;
            Delta = 0.0;
        }

        /// <summary>
        /// Gets the value of trade.
        /// </summary>
        /// <value>The value.</value>
        public double Value { get; set; }
        /// <summary>
        /// Gets the delta.
        /// </summary>
        /// <value>The delta.</value>
        public double Delta { get; set; }

        /// <summary>
        /// Adds to the value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void AddValue(double value) { Value += value; }
        /// <summary>
        /// Adds to the delta.
        /// </summary>
        /// <param name="delta">The delta.</param>
        public void AddDelta(double delta) { Delta += delta; }
    }
}
