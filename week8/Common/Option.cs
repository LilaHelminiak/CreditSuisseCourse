namespace CS.Trades
{
    public class Option : ITrade
    {
        public enum Type
        {
            Put, Call
        }

        public Option(Option.Type type, double notional, double strike, DateTime maturity)
        {
            OptionType = type;
            Notional = notional;
            Strike = strike;
            Maturity = maturity;
        }

        public String TradeType { get { return "Option"; } }

        public Type OptionType { get;  set; }
        public double Notional { get;  set; }
        public double Strike { get;  set; }
        public DateTime Maturity { get;  set; }
        
    }
}
