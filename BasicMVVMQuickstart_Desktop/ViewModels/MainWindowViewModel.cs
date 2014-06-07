// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using BasicMVVMQuickstart_Desktop.Model;
using Microsoft.Practices.Prism.Commands;

namespace BasicMVVMQuickstart_Desktop.ViewModels
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            this.MarketViewModel = new MarketViewModel();
            this.PortfolioViewModel = new PortfolioViewModel();
            this.ChartViewModel = new ChartViewModel();            
        }

        public ICommand SubmitCommand { get; private set; }

        public ICommand ResetCommand { get; private set; }

        public ChartViewModel ChartViewModel { get; set; }
        public MarketViewModel MarketViewModel { get; set; }
        public PortfolioViewModel PortfolioViewModel { get; set; }
        
    }
}
