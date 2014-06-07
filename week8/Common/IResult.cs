namespace CS.Pricer
{
    public interface IResult
    {
        double Value { get; }
        double Delta { get; }

        void AddValue(double value);
        void AddDelta(double delta);
    }
}
