using System;
using System.ServiceModel;
using System.Linq;
using CS.Market.MarketServiceReference;
using System.Threading;
using System.Timers;

namespace CS.Market
{
    class MarketPublisher: IMarketContractCallback
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Market App");
            
            using (ServiceHost host = new ServiceHost(typeof(MarketService)))
            {
                // Init Market Service
                host.Open();
                Console.WriteLine("The service is ready at: {0}", host.BaseAddresses.FirstOrDefault().ToString());

                // Init MarketData Publisher
                InstanceContext site = new InstanceContext(new MarketPublisher());
                MarketContractClient publisher = new MarketContractClient(site);
                
                // Evolve for MarketTickInterval
                var config = new MarketConfiguration();
                var logNormal = new LogNormalMarket(config);
                TimeSpan evolveTime = TimeSpan.FromHours(0);
                var myTimer = new System.Timers.Timer();
                myTimer.Elapsed += (sender, e) => EvolveAndPublish(sender, logNormal, evolveTime, publisher);
                myTimer.Interval = config.MarketTickInterval.TotalMilliseconds;
                myTimer.Enabled = true;

                //Publish MarketData                
                Console.ReadKey();


                host.Close();
            }
        }

        public static void EvolveAndPublish(object sender, LogNormalMarket logNormal, TimeSpan evolveTime, MarketContractClient publisher)
        {
            logNormal.Evolve(evolveTime += TimeSpan.FromHours(4));
            MarketData marketData = new MarketData() { Time = logNormal.Time, StockPrice = logNormal.StockPrice, VolSurface = logNormal.VolSurface };
            //Console.WriteLine("{0}, {1}, {2}", marketData.Time, marketData.VolSurface.Vol(TimeSpan.FromHours(4), marketData.StockPrice), marketData.StockPrice);
            publisher.PublishMarketData(marketData);
        }


        public void GetMarketData(MarketData marketdata)
        {
        }
    }
}
