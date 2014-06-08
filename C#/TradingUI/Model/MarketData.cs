using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicMVVMQuickstart_Desktop.Model
{
    public class MarketData
    {
        public DateTime businessDate { get; set; }
        public double Volatility { get; set; }
        public double Strike { get; set; }
    }
}
