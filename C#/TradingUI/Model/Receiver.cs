using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CS.Market;
using TradingUI.PricerServiceReference;

namespace TradingUI.Model
{
   
    public class Receiver : IPricerContractCallback
    {

        public OptionData optionData { get; set; }
        public MarketData marketData { get; set; }

        static public void SubscribeToService()
        {
            MessageBox.Show("Alive");
            InstanceContext site = new InstanceContext(null, new Receiver());
            PricerContractClient client = new PricerContractClient(site);

            //create a unique callback address so multiple clients can run on one machine
            WSDualHttpBinding binding = (WSDualHttpBinding)client.Endpoint.Binding;
            string clientcallbackaddress = binding.ClientBaseAddress.AbsoluteUri;
            clientcallbackaddress += Guid.NewGuid().ToString();
            binding.ClientBaseAddress = new Uri(clientcallbackaddress);

            //Subscribe.
            Console.WriteLine("Subscribing");
            client.Subscribe();

            //Closing the client gracefully closes the connection and cleans up resources
            //client.Close();

        }

        public void GetPricerData(TradingUI.PricerServiceReference.OptionData newOptionData)
        {
            marketData = (MarketData)newOptionData.MarketData;
        }
    }
}
