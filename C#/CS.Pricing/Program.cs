using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using CS.Market;
using CS.Pricing.MarketServiceReference;
using CS.Pricing.PricerServiceReference;
using CS.Trades.TradeTypes;

namespace CS.Pricing
{
    class Pricer : IMarketContractCallback, IPricerContractCallback
    {
        static void Main(string[] args)
        {
            publisherSite = new InstanceContext(new Pricer());
            publisher = new PricerContractClient(publisherSite);

            x = 100;
            Console.WriteLine("Pricing App");
            var pricer = new Pricer();
            pricer.HostPriceService();     

            // Every new MarketData price options from contract set
            // Publish OptionData

            // Handle adding option to contact set
        }
        public MarketContractClient client;
        public static InstanceContext publisherSite;
        public static PricerContractClient publisher;

        public void HostPriceService()
        {
            using (ServiceHost host = new ServiceHost(typeof(PricerService)))
            {
                // Init Pricer as a service for Trading UI
                host.Open();
                Console.WriteLine("The Pricer Service is ready at: {0}", host.BaseAddresses.FirstOrDefault().ToString());

                //Set Pricer as the client of MarketService and subscribe to it
                ClientMarketService();

                Console.WriteLine("Press <Enter> to stop the service");
                Console.ReadKey();
                host.Close();
            }
        }

        public static int x;

        public void ClientMarketService()
        {
            //Set Pricer as the client of MarketService
            InstanceContext clientSite = new InstanceContext(null, this);
            client = new MarketContractClient(clientSite);
            //create a unique callback address so multiple clients can run on one machine
            WSDualHttpBinding binding = (WSDualHttpBinding)client.Endpoint.Binding;
            string clientcallbackaddress = binding.ClientBaseAddress.AbsoluteUri;
            clientcallbackaddress += Guid.NewGuid().ToString();
            binding.ClientBaseAddress = new Uri(clientcallbackaddress);

            //Subscribe for MarketService
            Console.WriteLine("Subscribing to MarketService");
            client.Subscribe();
        }

        public void GetMarketData(MarketData marketData)
        {
            Console.WriteLine("Got new MarketData. Publishing OptionData");            
            var options = publisher.GetAllOptions();
            var result = new Result();
            result.Delta = 0.3;
            result.Value = 500;
            x+=100;

            var optionResults = new OptionResult[options.Length];
            for(var i=0; i < options.Length; i++)
            {
                var oResult = new OptionResult()
                {               
                    Contract = options[i],
                    BaseResult = result
                };
                optionResults[i] = oResult;
            }
            
            OptionData newOptionData = new OptionData()
            {
                MarketData = marketData,
                OptionResults = optionResults
            };

            
            publisher.PublishUIData(newOptionData);
            
            
        }

        public void GetPricerData(OptionData optionData)
        {
        }
    }
}
