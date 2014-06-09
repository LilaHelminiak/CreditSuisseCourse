using System;
using System.Linq;
using System.ServiceModel;
using CS.Market;
using CS.Pricing.MarketServiceReference;
using CS.Pricing.PricerServiceReference;

namespace CS.Pricing
{
    class Pricer : IMarketContractCallback, IPricerContractCallback
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pricing App");
            var pricer = new Pricer();
            pricer.HostPriceService();         



            // Every new MarketData price options from contract set
            // Publish OptionData

            // Handle adding option to contact set
        }

        public void HostPriceService()
        {
            using (ServiceHost host = new ServiceHost(typeof(PricerService)))
            {
                // Init Pricer as a service for Trading UI
                host.Open();
                Console.WriteLine("The Pricer Service is ready at: {0}", host.BaseAddresses.FirstOrDefault().ToString());


                //Set Pricer as the client of MarketService
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

                Console.WriteLine("Press <Enter> to stop the service");
                Console.ReadKey();
                host.Close();
            }
        }

        public void GetMarketData(MarketData marketData)
        {
            Console.WriteLine("Got new MarketData. Publishing OptionData");
            var result = new Result();
            result.Delta = 0.3;
            result.Value = 500;
            var oResult = new OptionResult()
            {
                BaseResult = result
            };
            OptionData newOptionData = new OptionData()
            {
                MarketData = marketData,
                OptionResults = new OptionResult[1] { oResult }
            };

            // Set Pricer as publisher of PricerService
            InstanceContext publisherSite = new InstanceContext(new Pricer());
            PricerContractClient publisher = new PricerContractClient(publisherSite);
            publisher.PublishUIData(newOptionData);
        }

        public void GetPricerData(OptionData optionData)
        {
        }
    }
}
