using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicMVVMQuickstart_Desktop.Model
{
    public class ConfigureData
    {
        public double DriftGBM { get; set; }
        public double VolatilityGBM { get; set; }
        public double HedgingVolatility { get; set; }
        public double Seed { get; set; }
        public double StockPrice { get; set; }
    }
}
