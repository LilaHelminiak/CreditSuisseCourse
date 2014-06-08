using System;
using System.Linq;
using System.ServiceModel;
using CS.Market;
using CS.Pricing.MarketServiceReference;
using CS.Pricing.PricerServiceReference;

namespace CS.Pricing
{
    class Pricer : IMarketContractCallback
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pricing App");

            
            using (ServiceHost host = new ServiceHost(typeof(PricerService)))
            {
                // Init Pricer as a service for Trading UI
                host.Open();
                Console.WriteLine("The Pricer Service is ready at: {0}", host.BaseAddresses.FirstOrDefault().ToString());

                
                // Set Pricer as the client of MarketService
                InstanceContext clientSite = new InstanceContext(null, new Pricer());
                MarketContractClient client = new MarketContractClient(clientSite);

                //create a unique callback address so multiple clients can run on one machine
                WSDualHttpBinding binding = (WSDualHttpBinding)client.Endpoint.Binding;
                string clientcallbackaddress = binding.ClientBaseAddress.AbsoluteUri;
                clientcallbackaddress += Guid.NewGuid().ToString();
                binding.ClientBaseAddress = new Uri(clientcallbackaddress);

                //Subscribe for MarketService
                Console.WriteLine("Subscribing to MarketService");
                client.Subscribe();

                // Set Pricer as publisher of PricerService
                InstanceContext publisherSite = new InstanceContext(new Pricer());
                PricerContractClient publisher = new PricerContractClient(publisherSite);

                Optio marketData = new MarketData();
                marketData.businessDate = DateTime.Parse("2015-02-13");
                marketData.StockPrice = 1000;

                Console.WriteLine("Sending PublishPriceChange(marketData)");
                //client.PublishPriceChange("Gold", 400.00D, -0.25D);
                client.PublishPriceChange(marketData);

                Console.WriteLine("Press <Enter> to stop the service");
                Console.ReadKey();
                host.Close();
            }        



            // Every new MarketData price options from contract set
            // Publish OptionData

            // Handle adding option to contact set
        }

        public void GetMarketData(MarketData marketData)
        {
            Console.WriteLine("Got new MarketData. Publishing OptionData");
            OptionData newOptionData = new OptionData();
            newOptionData.MarketData = marketData;
            newOptionData.OptionResults = new OptionResult[1];
            newOptionData.OptionResults[0] = new OptionResult( 
        }
    }
}
