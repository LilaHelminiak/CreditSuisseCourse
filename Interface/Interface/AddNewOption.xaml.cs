using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;

namespace Interface
{
    /// <summary>
    /// Interaction logic for AddNewOption.xaml
    /// </summary>
    public partial class AddNewOption : Window
    {
        BindingList<OptionData> list;
        public AddNewOption(BindingList<OptionData> list)
        {
            this.list = list;
            InitializeComponent();
        }

        private void CreateOption(object sender, RoutedEventArgs e)
        {
            var newOption = new OptionData(); 
            bool correctOption = true;

            typeWarningLabel.Visibility = Visibility.Hidden;
            priceWarningLabel.Visibility = Visibility.Hidden;
            dateWarningLabel.Visibility = Visibility.Hidden;

            if ((bool)PutButton.IsChecked)
                newOption.Type = "Put";
            else if ((bool)CallButton.IsChecked)
                newOption.Type = "Call";
            else
            {
                correctOption = false;
                typeWarningLabel.Visibility = Visibility.Visible;
                typeWarningLabel.Content = "Please select the type";
            }

            if (String.IsNullOrEmpty(Price.Text))
            {
                correctOption = false;
                priceWarningLabel.Visibility = Visibility.Visible;
                priceWarningLabel.Content = "Please enter the price";
            }
            else
            {
                try
                {
                    newOption.Price = Convert.ToDouble(Price.Text);

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
                newOption.Maturity = DateTime.Parse(Date.Text);
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
                list.Add(newOption);
                CloseWindow(sender, e);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
