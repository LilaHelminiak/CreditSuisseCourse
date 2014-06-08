using System;
using System.ServiceModel;
using System.Linq;


namespace CS.Market
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Market App");

            // Init market
            using (ServiceHost host = new ServiceHost(typeof(MarketService)))
            {
                host.Open();

                Console.WriteLine("The service is ready at: {0}", host.BaseAddresses.FirstOrDefault().ToString());
                Console.WriteLine("Press <Enter> to stop the service");
                Console.ReadKey();
                host.Close();
            }

            // Evolve for MarketTickInterval
            // Publish MarketData
        }
    }
}
