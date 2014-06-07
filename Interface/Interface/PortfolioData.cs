using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interface
{
    public class PortfolioData
    {
        public string Action { get; set; }
        public string Instrument { get; set; }
        public double Notional { get; set; }
        public double Value { get; set; }
        public double Delta { get; set; }
    }
}
