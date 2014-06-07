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
    /// Interaction logic for AddToPortfolio.xaml
    /// </summary>
    public partial class AddToPortfolio : Window
    {
        BindingList<PortfolioData> portfolioList;
        PortfolioData addOption;

        public AddToPortfolio(OptionData tradedOption, BindingList<PortfolioData> pList)
        {
            portfolioList = pList;
            addOption = new PortfolioData();
            addOption.Delta = -0.1;
            addOption.Instrument = tradedOption.Type + " option";
            addOption.Value = tradedOption.Price;

            InitializeComponent();
            typeLabel.Content = tradedOption.Type;
            priceLabel.Content = tradedOption.Price.ToString();
            dateLabel.Content = tradedOption.Maturity.ToShortDateString();
            volLabel.Content = "0.20";
            delLabel.Content = "-0.1";
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void CloseWin(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddToPor(object sender, RoutedEventArgs e)
        {
            bool correct = true;
            AmountWarning.Visibility = Visibility.Hidden;
            ActionWarning.Visibility = Visibility.Hidden;

            if ((bool)BuyButton.IsChecked)
                addOption.Action = "Buy";
            else if ((bool)SellButton.IsChecked)
                addOption.Action = "Sell";
            else
            {
                correct = false;
                ActionWarning.Content = "Please select the trade direction";
                ActionWarning.Visibility = Visibility.Visible;
            }

            double amount=0;
            try
            {
                amount = Double.Parse(AmountBox.Text);
            }
            catch(FormatException)
            {
                correct = false;
                AmountWarning.Content = "Please use digits and comma";
                AmountWarning.Visibility = Visibility.Visible;
            }
            catch(ArgumentNullException)
            {
                correct = false;
                AmountWarning.Content = "Enter the amount";
                AmountWarning.Visibility = Visibility.Visible;
            }
            if (amount < 0)
            {
                correct = false;
                AmountWarning.Content = "The amount has to be positive";
                AmountWarning.Visibility = Visibility.Visible;

            }
            if(correct)
            {
                addOption.Notional = amount;
                portfolioList.Add(addOption);
                CloseWin(sender, e);
            }
        }
    }
}
