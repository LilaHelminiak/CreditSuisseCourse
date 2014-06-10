using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
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

        private int chartCounter;
        static private ObservableCollection<KeyValuePair<String, double>> _chartData;
        public ObservableCollection<KeyValuePair<String, double>> chartData
        {
            get { return _chartData; }
            set
            {
                _chartData = value;
                OnPropertyChanged("chartData");
            }
        }

        public List<OptionResult> _optionList;
        public List<OptionResult> optionList {
            get
            {
                return _optionList;
            }
            set
            {
                _optionList = value;
                OnPropertyChanged("optionList");
            }
        }
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

            this.optionList = new List<OptionResult>() {new OptionResult(){Contract = new OptionContract(OptionContract.Type.Put, 1, 1300, DateTime.Parse("2015-05-14"))}};
            _chartData = new ObservableCollection<KeyValuePair<string, double>>();
            chartCounter = 0;
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
        }

        public void UnsubscribeFromService()
        {
            client.Close();
        }

        public void AddOptionToPricer(OptionContract option)
        {
            client.AddNewOption(option);
        }

        public List<OptionContract> GetAllOptions()
        {
            return client.GetAllOptions().ToList();
        }


        public void GetPricerData(OptionData newOptionData)
        {            
            MarketData = newOptionData.MarketData;
            Application.Current.Dispatcher.BeginInvoke(
                DispatcherPriority.Background, new Action(() =>
                    {
                        if (_chartData.Count == 50)
                            _chartData.RemoveAt(0);
                        chartCounter += 1;
                        _chartData.Add(new KeyValuePair<string, double>("t" + chartCounter.ToString(), MarketData.StockPrice)); }
                    ));
            
            //var tempOptionList = new List<OptionResult>();
  
            optionList = newOptionData.OptionResults.ToList();
        }
    }
}
