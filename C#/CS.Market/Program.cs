﻿using System;
using System.ServiceModel;
using System.Linq;
using CS.Market.MarketServiceReference;
using System.Threading;

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

                // Init MarketData Publisher Publish MarketData
                InstanceContext site = new InstanceContext(new MarketPublisher());
                MarketContractClient publisher = new MarketContractClient(site);
                
                // Evolve for MarketTickInterval
                MarketData marketData = new MarketData();
                marketData.Time = DateTime.Parse("2015-02-13");
                marketData.StockPrice = 1000;

                //Publish MarketData                
                while(true)
                {
                    Console.WriteLine("Hit enter to PublishMarketData(marketData)");
                    Console.ReadKey();
                    marketData.Time = marketData.Time.AddDays(1);
                    marketData.StockPrice += 100;
                    publisher.PublishMarketData(marketData);

                }                
                Console.WriteLine("Press <Enter> to stop the service");
                Console.ReadKey();
                host.Close();
            }
        }

        public void GetMarketData(MarketData marketdata)
        {
        }
    }
}
