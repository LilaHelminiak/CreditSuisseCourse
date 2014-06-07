using System;
using DataGeneratorServiceLibrary;

namespace CS.Market
{
    public class CalculateStock: IEvolve, IMarketData
    {
        public DateTime Time { get; set; }
        public double StockPrice { get; set; }
        public double ImpliedVolatility { get; set; }
        

        private int timeSteps, seed;
        private double my, sigma;

        //variable needed for generating normal random variables
        private Random fixRand;
        

        //variables needed for estimating the volatility
        private double[] R;
        private double avgR;

        public CalculateStock(int timeSteps, double my, double sigma, double price, int seed)
        {
            this.timeSteps = timeSteps;
            this.my = my;
            this.sigma = sigma;

            StockPrice = price;
            Time = DateTime.Now-TimeSpan.FromMinutes(15);

            fixRand = new Random(seed);

            R = new double[timeSteps];
            avgR = 0;
        }

        public IMarketData RunCalculation()
        {
            TimeSpan timeDiffrence = DateTime.Now - Time;
            TimeSpan offset = TimeSpan.FromMinutes((DateTime.Now - Time).TotalMinutes / this.timeSteps);
            for (int i = 0; i < timeSteps; i++)
            {
                double oldPrice = StockPrice;
                this.Evolve(offset);
                this.R[i] = Math.Log((StockPrice * offset.TotalDays) / oldPrice);
                this.avgR += R[i];
            }
            ImpliedVolatility = EstimateVolatility(timeDiffrence);

            return new MarketData(){ImpliedVolatility = ImpliedVolatility, StockPrice = StockPrice, Time = Time};
        }
        
        public void Evolve(TimeSpan offset)
        {
            double exponent = (this.my - (Math.Pow(this.sigma, 2) / 2)) * offset.TotalDays/365 + 
                              (sigma * Math.Sqrt(offset.TotalDays/365) * NorRandVar());
            StockPrice = StockPrice * Math.Pow(Math.E, exponent);
            Time = Time + offset;
        }

        public double EstimateVolatility(TimeSpan offset)
        {
            double result = 0;
            this.avgR /= timeSteps;
            for (int i = 0; i < timeSteps; i++)
            {
                result += Math.Pow((R[i] - this.avgR), 2);
            }

            result *= this.timeSteps / (offset.TotalDays / 365 * timeSteps - 1);
            return Math.Sqrt(result);
        }

        private double NorRandVar()
        {
            double randomVal = this.fixRand.NextDouble();
            return CS.Numerical.NormalDistribution.InverseCDF(randomVal);
        }
    }
}
