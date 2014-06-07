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
            InstanceContext site = new InstanceContext(new Client());
            SampleContractClient client = new SampleContractClient(site);

            MarketData marketData = new MarketData();
            marketData.businessDate = DateTime.Parse("2015-02-13");
            marketData.StockPrice = 1000;

            Console.WriteLine("Sending PublishPriceChange(marketData)");
            //client.PublishPriceChange("Gold", 400.00D, -0.25D);
            client.PublishPriceChange(marketData);

            

            Console.WriteLine();
            Console.WriteLine("Press ENTER to shut down data source");
            Console.ReadLine();

            //Closing the client gracefully closes the connection and cleans up resources
            client.Close();
        }

        public void PriceChange(MarketData marketData)
        {
            Console.WriteLine("PriceChange(businessDate {0}, price {1})", marketData.businessDate, marketData.StockPrice.ToString("C"));
        }

    }
}

