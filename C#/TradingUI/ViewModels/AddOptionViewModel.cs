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

namespace TradingUI.ViewModels
{
    public class AddOptionViewModel : BindableBase
    {
        BindingList<OptionData> optionList;

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

        public AddOptionViewModel(BindingList<OptionData> optionList)
        {
            this.AddOptionCommand = new DelegateCommand<object>(this.AddOption);
            this.CloseWindowCommand = new DelegateCommand<object>(this.Close);

            this.optionList = optionList;
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
            var newOption = new OptionData();
            bool correctOption;

            typeWarningLabel.Visibility = Visibility.Hidden;
            priceWarningLabel.Visibility = Visibility.Hidden;
            dateWarningLabel.Visibility = Visibility.Hidden;
            existWarningLabel.Visibility = Visibility.Hidden;

            correctOption = CheckButtons(newOption);
            correctOption = CheckPrice(newOption) && correctOption;
            correctOption = CheckDate(newOption) && correctOption;
            correctOption = CheckExist(newOption) && correctOption;            

            if (correctOption)
            {
                optionList.Add(newOption);
                this.Close(obj);
            }
        }



        private bool CheckButtons(OptionData newOption)
        {
            if (PutButton)
            {
                newOption.Type = "Put";
                return true;
            }
            else if (CallButton)
            {
                newOption.Type = "Call";
                return true;
            }
            else
            {
                typeWarningLabel.Visibility = Visibility.Visible;
                typeWarningLabel.Content = "Please select the type";
                return false;
            }
        }

        private bool CheckPrice(OptionData newOption)
        {
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
                    newOption.Price = Convert.ToDouble(priceTextbox);
                    return true;
                }
                catch (FormatException)
                {
                    priceWarningLabel.Visibility = Visibility.Visible;
                    priceWarningLabel.Content = "Please use digits and/or the comma";
                    return false;
                }
            }
        }

        private bool CheckDate(OptionData newOption)
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
            {
                newOption.Maturity = (DateTime)maturityDate;
                return true;
            }
        }      
        
        private bool CheckExist(OptionData newOption)
        {
            var result = optionList.FirstOrDefault(option => option.Type == newOption.Type && option.Price == newOption.Price && option.Maturity == newOption.Maturity);
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
