// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ServiceModel;
using System.Windows.Input;
using TradingUI.Model;
using TradingUI.Views;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using CS.Pricing;

namespace TradingUI.ViewModels
{
    public class MarketViewModel : BindableBase
    {

        public BindingList<PortfolioData> portfolioList { get; set; } 

        private ObservableCollection<KeyValuePair<String, double>> _chartData;
        public ObservableCollection<KeyValuePair<String, double>> chartData
        {
            get { return _chartData; }
            set { 
                _chartData = value;
                OnPropertyChanged("chartData");
            }
        }

        public OptionResult _selectedOption;
        public OptionResult selectedOption {
            get { return _selectedOption; }
            set
            {
               _selectedOption= value;
                OnPropertyChanged("selectedOption");
                if(value != null)
                    lastSelectedOption = _selectedOption;
            }
        }
        public OptionResult lastSelectedOption;
        public Receiver dataReceiver { get; set; }

        public ICommand AddOptionCommand { get; set; }
        public ICommand TradeOptionCommand { get; set; }

        public MarketViewModel(BindingList<PortfolioData> portfolioList, Receiver dataReceiver)
        {
            this.portfolioList = portfolioList;
            _chartData = new ObservableCollection<KeyValuePair<string, double>>();
            _chartData.Add(new KeyValuePair<String, double>("2014-06-10", 121));
            this.dataReceiver = dataReceiver;
            this.AddOptionCommand = new DelegateCommand<object>(this.ShowAddOptionDialog);
            this.TradeOptionCommand = new DelegateCommand<object>(this.ShowTradeOptionDialog);

        }

        public void ShowAddOptionDialog(object obj)
        {
            var newWindow = new AddOption();
            var viewModel = new AddOptionViewModel(dataReceiver);
            viewModel.RequestClose += newWindow.Close;
            newWindow.DataContext = viewModel;
            newWindow.Show();
        }


        public void ShowTradeOptionDialog(object obj)
        {
            if (lastSelectedOption != null)
            {
                var newWindow = new TradeOption();
                var viewModel = new TradeOptionViewModel(portfolioList, lastSelectedOption);
                viewModel.RequestClose += newWindow.Close;
                newWindow.DataContext = viewModel;
                newWindow.Show();
            }
        }

    }
}
