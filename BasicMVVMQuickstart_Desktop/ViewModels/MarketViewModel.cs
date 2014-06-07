// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using BasicMVVMQuickstart_Desktop.Model;
using BasicMVVMQuickstart_Desktop.Views;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;

namespace BasicMVVMQuickstart_Desktop.ViewModels
{
    public class MarketViewModel : BindableBase
    {
        public BindingList<OptionData> optionList;
        public ICommand AddOptionCommand { get; set; }
        public ICommand TradeOptionCommand { get; set; }
        public MarketViewModel()
        {
            this.AddOptionCommand = new DelegateCommand<object>(this.ShowAddOptionDialog);
            this.TradeOptionCommand = new DelegateCommand<object>(this.TradeOption);
        }

        public void ShowAddOptionDialog(object obj)
        {
            var newWindow = new AddOption();
            var viewModel = new AddOptionViewModel(optionList);
            viewModel.RequestClose += newWindow.Close;
            newWindow.DataContext = viewModel;
            newWindow.Show();
        }

        public void TradeOption(object obj)
        {

        }

    }
}
