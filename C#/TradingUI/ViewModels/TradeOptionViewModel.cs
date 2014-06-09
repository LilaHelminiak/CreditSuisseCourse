// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Windows.Input;
using TradingUI.Model;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using System.Windows;
using System.ComponentModel;

namespace TradingUI.ViewModels
{
    public class TradeOptionViewModel : BindableBase
    {
        public OptionDataGrid selectedOption { get; set; }
        public BindingList<PortfolioData> portfolioList { get; set; }

        public event Action RequestClose;
        public ICommand TradeOptionCommand { get; set; }
        public ICommand CloseWindowCommand { get; set; }

        public WarningLabel actionWarningLabel { get; set; }
        public WarningLabel notionalWarningLabel { get; set; }

        public bool BuyButton { get; set; }
        public bool SellButton { get; set; }
        public string notionalTextbox { get; set; }

        public TradeOptionViewModel(BindingList<PortfolioData> portfolioList, OptionDataGrid selectedOption)
        {
            this.TradeOptionCommand = new DelegateCommand<object>(this.TradeOption);
            this.CloseWindowCommand = new DelegateCommand<object>(this.Close);

            this.selectedOption = selectedOption;
            this.portfolioList = portfolioList;
            this.actionWarningLabel = new WarningLabel();
            this.notionalWarningLabel = new WarningLabel();
        }

        public virtual void Close(object obj)
        {
            if (RequestClose != null)
            {
                RequestClose();
            }
        }

        public void TradeOption(object obj)
        {
            var newEntry = new PortfolioData();
            bool correctOption;

            actionWarningLabel.Visibility = Visibility.Hidden;
            notionalWarningLabel.Visibility = Visibility.Hidden;

            correctOption = CheckButtons(newEntry);
            correctOption = CheckNotional(newEntry) && correctOption;
                     
            if (correctOption)
            {
                portfolioList.Add(newEntry);
                this.Close(obj);
            }
        }

        private bool CheckButtons(PortfolioData newEntry)
        {
            /*if (BuyButton)
            {
                newEntry.Type = "Put";
                return true;
            }
            else if (SellButton)
            {
                newEntry.Type = "Call";
                return true;
            }
            else
            {
                actionWarningLabel.Visibility = Visibility.Visible;
                actionWarningLabel.Content = "Please select the type";
                return false;
            }*/
            return false;
        }

        private bool CheckNotional(PortfolioData newEntry)
        {
            /*
            if (String.IsNullOrEmpty(notionalTextbox))
            {
                notionalWarningLabel.Visibility = Visibility.Visible;
                notionalWarningLabel.Content = "Please enter the price";
                return false;
            }
            else
            {
                try
                {
                    newEntry.Price = Convert.ToDouble(notionalTextbox);
                    return true;
                }
                catch (FormatException)
                {
                    notionalWarningLabel.Visibility = Visibility.Visible;
                    notionalWarningLabel.Content = "Please use digits and/or the comma";
                    return false;
                }
            }*/
            return false;
        }

    }
}
