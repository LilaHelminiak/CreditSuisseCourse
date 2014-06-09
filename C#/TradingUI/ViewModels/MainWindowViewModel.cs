// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using TradingUI.Model;
using Microsoft.Practices.Prism.Commands;
using System.Threading.Tasks;
using System;

namespace TradingUI.ViewModels
{
    public class MainWindowViewModel
    {
        public BindingList<PortfolioData> portfolioData;
        public Receiver dataReceiver;
        public MainWindowViewModel()
        {
            portfolioData = new BindingList<PortfolioData>();
            dataReceiver = new Receiver();
            Task task1 = new Task(new Action(Receiver.SubscribeToService));
            task1.Start();

            this.MarketViewModel = new MarketViewModel(portfolioData, dataReceiver);
            this.PortfolioViewModel = new PortfolioViewModel();
            this.ChartViewModel = new ChartViewModel();            
        }

        public ChartViewModel ChartViewModel { get; set; }
        public MarketViewModel MarketViewModel { get; set; }
        public PortfolioViewModel PortfolioViewModel { get; set; }
        
    }
}
