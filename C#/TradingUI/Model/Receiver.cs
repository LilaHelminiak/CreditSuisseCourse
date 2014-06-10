﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
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

        public List<OptionDataGrid> _optionList;
        public List<OptionDataGrid> optionList {
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

            this.optionList = new List<OptionDataGrid>() {new OptionDataGrid(){OptionType="Put", Maturity=DateTime.Now, Price=20}};

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


        public void GetPricerData(OptionData newOptionData)
        {            
            MarketData = newOptionData.MarketData;

            var tempOptionList = new List<OptionDataGrid>();
            foreach (var option in newOptionData.OptionResults)
            {
                tempOptionList.Add(new OptionDataGrid() 
                { 
                    Price = option.Contract.Strike, 
                    Maturity = option.Contract.Maturity, 
                    OptionType =  option.Contract.OptionType.ToString()
                });
            }
            optionList = tempOptionList;
        }
    }
}
