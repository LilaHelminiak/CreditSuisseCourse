// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Windows.Input;
using BasicMVVMQuickstart_Desktop.Model;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using System.Windows;
using System.ComponentModel;

namespace BasicMVVMQuickstart_Desktop.ViewModels
{
    public class AddOptionViewModel : BindableBase
    {
        OptionData newOption;
        BindingList<OptionData> optionList;

        public event Action RequestClose;
        public ICommand AddOptionCommand { get; set; }
        public ICommand CloseWindowCommand { get; set; }

        public WarningLabel typeWarningLabel;
        public WarningLabel priceWarningLabel;
        public WarningLabel dateWarningLabel;

        public bool PutButton;
        public bool CallButton;
        public DateTime maturityDate;
        public string priceTextbox;

        public AddOptionViewModel(BindingList<OptionData> optionList)
        {
            this.AddOptionCommand = new DelegateCommand<object>(this.AddOption);
            this.CloseWindowCommand = new DelegateCommand<object>(this.Close);

            this.optionList = optionList;
            this.typeWarningLabel = new WarningLabel();
            this.priceWarningLabel = new WarningLabel();
            this.dateWarningLabel = new WarningLabel();
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
            bool correctOption = true;

            typeWarningLabel.Visibility = Visibility.Hidden;
            priceWarningLabel.Visibility = Visibility.Hidden;
            dateWarningLabel.Visibility = Visibility.Hidden;

            if (PutButton)
                newOption.Type = "Put";
            else if (CallButton)
                newOption.Type = "Call";
            else
            {
                correctOption = false;
                typeWarningLabel.Visibility = Visibility.Visible;
                typeWarningLabel.Content = "Please select the type";
            }

            if (String.IsNullOrEmpty(priceTextbox))
            {
                correctOption = false;
                priceWarningLabel.Visibility = Visibility.Visible;
                priceWarningLabel.Content = "Please enter the price";
            }
            else
            {
                try
                {
                    newOption.Price = Convert.ToDouble(priceTextbox);

                }
                catch (FormatException)
                {
                    correctOption = false;
                    priceWarningLabel.Visibility = Visibility.Visible;
                    priceWarningLabel.Content = "Please use digits and/or the comma";
                }
            }


            try
            {
                newOption.Maturity = this.maturityDate;
            }
            catch (ArgumentNullException)
            {
                correctOption = false;
                dateWarningLabel.Visibility = Visibility.Visible;
                dateWarningLabel.Content = "Please select a date";
            }
            catch (FormatException)
            {
                correctOption = false;
                dateWarningLabel.Visibility = Visibility.Visible;
                dateWarningLabel.Content = "Please enter the date in format: yyy-mm-dd";
            }
            if (newOption.Maturity < DateTime.Today)
            {
                correctOption = false;
                dateWarningLabel.Visibility = Visibility.Visible;
                dateWarningLabel.Content = "Please enter the future date";
            }

            if (correctOption)
            {
                optionList.Add(newOption);
                this.Close(obj);
            }
        }

    }
}
