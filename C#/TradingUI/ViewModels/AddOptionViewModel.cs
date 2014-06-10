// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Input;
using TradingUI.Model;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using System.Windows;
using System.ComponentModel;
using CS.Trades.TradeTypes;
using CS.Pricing;

namespace TradingUI.ViewModels
{
    public class AddOptionViewModel : BindableBase
    {
        public Receiver dataReceiver;

        public event Action RequestClose;
        public ICommand AddOptionCommand { get; set; }
        public ICommand CloseWindowCommand { get; set; }

        public WarningLabel typeWarningLabel { get; set; }
        public WarningLabel priceWarningLabel { get; set; }
        public WarningLabel dateWarningLabel { get; set; }
        public WarningLabel existWarningLabel { get; set; }

        public bool PutButton { get; set; }
        public bool CallButton { get; set; }
        public DateTime? maturityDate { get; set; }
        public string priceTextbox { get; set; }

        public AddOptionViewModel(Receiver dataReceiver)
        {
            this.dataReceiver = dataReceiver;

            this.AddOptionCommand = new DelegateCommand<object>(this.AddOption);
            this.CloseWindowCommand = new DelegateCommand<object>(this.Close);

            this.typeWarningLabel = new WarningLabel();
            this.priceWarningLabel = new WarningLabel();
            this.dateWarningLabel = new WarningLabel();
            this.existWarningLabel = new WarningLabel();
        }

        public virtual void Close(object obj)
        {
            if (RequestClose != null)
            {
                RequestClose();
            }
        }

        public void AddOption(object obj)
        {
            bool correctOption;

            typeWarningLabel.Visibility = Visibility.Hidden;
            priceWarningLabel.Visibility = Visibility.Hidden;
            dateWarningLabel.Visibility = Visibility.Hidden;
            existWarningLabel.Visibility = Visibility.Hidden;

            correctOption = CheckButtons();
            correctOption = CheckPrice() && correctOption;
            correctOption = CheckDate() && correctOption;
          

            if (correctOption)
            {
                OptionContract.Type optionType;
                if(PutButton)
                    optionType = OptionContract.Type.Put;
                else 
                    optionType = OptionContract.Type.Call;
                double Strike = Convert.ToDouble(priceTextbox);   
                DateTime Maturity = (DateTime)maturityDate;

                OptionContract optionContract = new OptionContract(optionType, 1, Strike, Maturity);
                if(CheckExist(optionContract))
                    dataReceiver.AddOptionToPricer(optionContract);

                this.Close(obj);
            }
        }



        private bool CheckButtons()
        {
            if (PutButton || CallButton)
            {
                return true;
            }
            else
            {
                typeWarningLabel.Visibility = Visibility.Visible;
                typeWarningLabel.Content = "Please select the type";
                return false;
            }
        }

        private bool CheckPrice()
        {
            double price;
            if (String.IsNullOrEmpty(priceTextbox))
            {
                priceWarningLabel.Visibility = Visibility.Visible;
                priceWarningLabel.Content = "Please enter the price";
                return false;
            }
            else
            {
                
                try
                {
                    price = Convert.ToDouble(priceTextbox);                    
                }
                catch (FormatException)
                {
                    priceWarningLabel.Visibility = Visibility.Visible;
                    priceWarningLabel.Content = "Please use digits and/or the comma";
                    return false;
                }
            }
            if (price < 0)
            {
                priceWarningLabel.Visibility = Visibility.Visible;
                priceWarningLabel.Content = "The price can not be negative";
                return false;
            }
            else
                return true;
        }

        private bool CheckDate()
        {
            if( maturityDate == null)
            {
                dateWarningLabel.Visibility = Visibility.Visible;
                dateWarningLabel.Content = "Please select a date or write \nin format yyyy-MM-dd";
                return false;
            }

            if (maturityDate < DateTime.Today)
            {
                dateWarningLabel.Visibility = Visibility.Visible;
                dateWarningLabel.Content = "Please enter the future date";
                return false;
            }
            else
                return true;
        }      
        
        private bool CheckExist(OptionContract newOption)
        {
            var optionList = dataReceiver.GetAllOptions();
            var result = optionList.FirstOrDefault(option => option.OptionType == newOption.OptionType && option.Strike == newOption.Strike && option.Maturity == newOption.Maturity);
            if (result == null)
                return true;
            else
            {
                existWarningLabel.Visibility = Visibility.Visible;
                existWarningLabel.Content = "Option is already in the market";
                return false;
            }
        }

    }
}
