using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CS.Market;
using CS.Pricing;
using CS.Trades.TradeTypes;
using TradingUI.PricerServiceReference;

namespace TradingUI.Model
{
   
    public class Receiver : IPricerContractCallback, INotifyPropertyChanged
    {
        private PricerContractClient client;
        public event PropertyChangedEventHandler PropertyChanged;
        private MarketData _marketData; 
        public OptionData optionData { get; set; }
        public MarketData MarketData {
            get
            { return _marketData; }
            set
            { 
                _marketData = value;
                OnPropertyChanged("marketData");
            }
        }

        public Receiver()
        {
            InstanceContext site = new InstanceContext(null, this);
            client = new PricerContractClient(site);

            //create a unique callback address so multiple clients can run on one machine
            WSDualHttpBinding binding = (WSDualHttpBinding)client.Endpoint.Binding;
            string clientcallbackaddress = binding.ClientBaseAddress.AbsoluteUri;
            clientcallbackaddress += Guid.NewGuid().ToString();
            binding.ClientBaseAddress = new Uri(clientcallbackaddress);
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public void SubscribeToService()
        {
            InstanceContext site = new InstanceContext(null, this);
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

        public void AddOptionToPricer(OptionContract option)
        {
            client.AddNewOption(option);
        }



        public void GetPricerData(OptionData newOptionData)
        {
            
            MarketData = (MarketData)newOptionData.MarketData;
        }
    }
}
