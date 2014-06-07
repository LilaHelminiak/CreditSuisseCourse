//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ServiceModel;
using ServiceReference1;

namespace Microsoft.ServiceModel.Samples
{
    //The service contract is defined in generatedClient.cs, generated from the service by the svcutil tool.
    //Client implementation code.

    class Client : ISampleContractCallback
    {
        static void Main(string[] args)
        {
            InstanceContext site = new InstanceContext(null, new Client());
            SampleContractClient client = new SampleContractClient(site);

            //create a unique callback address so multiple clients can run on one machine
            WSDualHttpBinding binding = (WSDualHttpBinding)client.Endpoint.Binding;
            string clientcallbackaddress = binding.ClientBaseAddress.AbsoluteUri;
            clientcallbackaddress += Guid.NewGuid().ToString();
            binding.ClientBaseAddress = new Uri(clientcallbackaddress);

            //Subscribe.
            Console.WriteLine("Subscribing");
            var marketData = new MarketData{ businessDate = DateTime.Now, StockPrice = 1000 };
            client.Subscribe();
            //Console.Write("Publishing: ");
            //Console.WriteLine("PriceChange(businessDate {0}, price {1})", marketData.businessDate.ToShortDateString(), marketData.StockPrice.ToString("C"));
            client.PublishPriceChange(new MarketData { businessDate = DateTime.Now, StockPrice = 1000 });

            Console.WriteLine();
            Console.WriteLine("Press ENTER to unsubscribe and shut down client");
            Console.ReadLine();

            Console.WriteLine("Unsubscribing");
            client.Unsubscribe();

            //Closing the client gracefully closes the connection and cleans up resources
            client.Close();

        }

        public void PriceChange(MarketData marketData)
        {
            Console.WriteLine("PriceChange(businessDate {0}, price {1})", marketData.businessDate.ToShortDateString(), marketData.StockPrice.ToString("C"));
        }
    }
}

