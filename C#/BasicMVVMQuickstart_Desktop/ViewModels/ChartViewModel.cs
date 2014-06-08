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
        private ObservableCollection<KeyValuePair<int, int>> _data;
        public ObservableCollection<KeyValuePair<int, int>> data
        {
            get { return _data; }
        }

        public ChartViewModel()
        {
            _data = new ObservableCollection<KeyValuePair<int, int>>();

            _data.Add(new KeyValuePair<int, int>(0, 0));
            _data.Add(new KeyValuePair<int, int>(10, 50));
            _data.Add(new KeyValuePair<int, int>(4, 11));
        }

    }
}
