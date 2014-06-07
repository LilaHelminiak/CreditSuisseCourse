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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace Interface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BindingList<OptionData> optionList;
        BindingList<PortfolioData> portfolioList;
        
        public MainWindow()
        {
            InitializeComponent();
            portfolioList = new BindingList<PortfolioData>();
            optionList = new BindingList<OptionData>();
         
            optionDataGrid.ItemsSource = optionList;
            portfolioDataGrid.ItemsSource = portfolioList;

            MarketDate.Content = "Date: " + DateTime.Now.ToShortDateString();
            MarketPrice.Content = "Strike price: 100";
            MarketVol.Content = "Volatility: 2%";

        }

        private void AddOption(object sender, RoutedEventArgs e)
        {
            var newWindow = new AddNewOption(optionList);
            newWindow.Show();
        }

        public void AddToPortfolio(object sender, RoutedEventArgs e)
        {
            OptionData tradedOption = (OptionData)optionDataGrid.SelectedItem;

            var newWindow = new AddToPortfolio(tradedOption, portfolioList);
            newWindow.Show();

        }

        private void GeneratePnL(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("PnL Chart generated");

        }
    }
}
