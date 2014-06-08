using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TradingUI.Model;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;

namespace TradingUI.ViewModels
{
    public class ConfigureMarketViewModel : BindableBase
    {
        public event Action RequestClose;
        public ICommand StartSimulationCommand { get; set; }
        public ICommand CloseWindowCommand { get; set; }

        public ConfigureData ConfigureData { get; set; }
        //public MarketData Market { get; set; }

        public ConfigureMarketViewModel()
        {
            this.CloseWindowCommand = new DelegateCommand<object>(this.Close);
            this.StartSimulationCommand = new DelegateCommand<object>(this.StartSimulation);

            this.ConfigureData = new ConfigureData();
            //this.Market = Market;
        }

        public virtual void Close(object obj)
        {
            if (RequestClose != null)
            {
                RequestClose();
            }
        }

        public void StartSimulation(object obj)
        {
            MessageBox.Show("simulation started");
            //TODO:
            //Check the fields of configuredata
            //add proper data to market
        }
    }
}
