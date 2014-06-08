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

namespace TradingUI.ViewModels
{
    public class MarketViewModel : BindableBase
    {
        public BindingList<OptionData> optionList { get; set; }
        public BindingList<PortfolioData> portfolioList { get; set; }

        public OptionData selectedOption { get; set; }
        //public MarketData Market { get; set; }

        public ICommand AddOptionCommand { get; set; }
        public ICommand TradeOptionCommand { get; set; }
        public ICommand ConfigureMarketCommand { get; set; }

        public MarketViewModel(BindingList<PortfolioData> portfolioList)
        {
            this.portfolioList = portfolioList;
            optionList = new BindingList<OptionData>();
            //test
            var t = new OptionData();
            t.Maturity = DateTime.Parse("2015-09-18");
            t.Price = 100;
            t.Type = "Put";
            optionList.Add(t);
            //end-test
            //this.Market = new MarketData();
            this.AddOptionCommand = new DelegateCommand<object>(this.ShowAddOptionDialog);
            this.TradeOptionCommand = new DelegateCommand<object>(this.ShowTradeOptionDialog);
            this.ConfigureMarketCommand = new DelegateCommand<object>(this.ShowConfigureMarketDialog);


        }

        public void ShowAddOptionDialog(object obj)
        {
            var newWindow = new AddOption();
            var viewModel = new AddOptionViewModel(optionList);
            viewModel.RequestClose += newWindow.Close;
            newWindow.DataContext = viewModel;
            newWindow.Show();
        }

        public void ShowConfigureMarketDialog(object obj)
        {            
            var newWindow = new ConfigureMarket();
            var viewModel = new ConfigureMarketViewModel();
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
