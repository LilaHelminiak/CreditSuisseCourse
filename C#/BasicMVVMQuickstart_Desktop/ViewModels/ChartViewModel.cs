// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using BasicMVVMQuickstart_Desktop.Model;
using Microsoft.Practices.Prism.Mvvm;
using System.Windows.Forms.DataVisualization.Charting;

namespace BasicMVVMQuickstart_Desktop.ViewModels
{
    public class ChartViewModel : BindableBase
    {
        public ObservableCollection<ChartElement> PnL { get; set; }

        public class point : ChartElement
        {
            public double x;
            public double y;
            public point(double x, double y)
            {
                this.x = x;
                this.y = y;
            }
        }
        public ChartViewModel()
        {
            PnL = new ObservableCollection<ChartElement>();
            PnL.Add(new point(0, 0));
            PnL.Add(new point(10, 20));
            PnL.Add(new point(30, 10));
        }

    }
}
