// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using BasicMVVMQuickstart_Desktop.ViewModels;

namespace BasicMVVMQuickstart_Desktop
{
    public class QuestionnaireViewDesignViewModel
    {
        public QuestionnaireViewDesignViewModel()
        {
            this.PortfolioViewModel = new PortfolioViewModel();
            this.MarketViewModel = new MarketViewModel();
            this.ChartViewModel = new ChartViewModel();
        }

        public PortfolioViewModel PortfolioViewModel { get; set; }
        public MarketViewModel MarketViewModel { get; set; }
        public ChartViewModel ChartViewModel { get; set; }

    }
}
