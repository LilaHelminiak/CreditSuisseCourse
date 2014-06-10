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

namespace TradingUI.ViewModels
{
    public class MarketViewModel : BindableBase
    {
        public BindingList<OptionDataGrid> optionList { get; set; }
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

        public OptionDataGrid selectedOption { get; set; }
        public Receiver dataReceiver { get; set; }

        public ICommand AddOptionCommand { get; set; }
        public ICommand TradeOptionCommand { get; set; }

        public MarketViewModel(BindingList<PortfolioData> portfolioList, Receiver dataReceiver)
        {
            this.portfolioList = portfolioList;
            optionList = new BindingList<OptionDataGrid>();
            _chartData = new ObservableCollection<KeyValuePair<string, double>>();
            _chartData.Add(new KeyValuePair<String, double>("2014-06-10", 121));
            this.dataReceiver = dataReceiver;
            this.AddOptionCommand = new DelegateCommand<object>(this.ShowAddOptionDialog);
            this.TradeOptionCommand = new DelegateCommand<object>(this.ShowTradeOptionDialog);

        }

        public void ShowAddOptionDialog(object obj)
        {
            var newWindow = new AddOption();
            var viewModel = new AddOptionViewModel(optionList, dataReceiver);
            viewModel.RequestClose += newWindow.Close;
            newWindow.DataContext = viewModel;
            newWindow.Show();
        }


        public void ShowTradeOptionDialog(object obj)
        {
            var newWindow = new TradeOption();
            var viewModel = new TradeOptionViewModel(portfolioList, selectedOption);
            viewModel.RequestClose += newWindow.Close;
            newWindow.DataContext = viewModel;
            newWindow.Show();
        }

    }
}
