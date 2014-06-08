
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

// This WCF sample implements the List-based Publish-Subscribe Design Pattern.

using System;
using System.ServiceModel;
using System.Diagnostics;

namespace MarketServiceLibrary
{

    [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerSession)]
    public class SampleService : IMarketService.ISampleContract
    {
        public static event PriceChangeEventHandler PriceChangeEvent;
        public delegate void PriceChangeEventHandler(object sender, MarketData newData);

        IMarketService.ISampleClientContract callback = null;

        PriceChangeEventHandler priceChangeHandler = null;

        public void Subscribe()
        {
            callback = OperationContext.Current.GetCallbackChannel<IMarketService.ISampleClientContract>();
            priceChangeHandler = new PriceChangeEventHandler(PriceChangeHandler);
            PriceChangeEvent += priceChangeHandler;
        }

        public void Unsubscribe()
        {
            PriceChangeEvent -= priceChangeHandler;
        }

        public void PublishPriceChange(MarketData newData)
        {
            PriceChangeEvent(this, newData);
        }

        public void PriceChangeHandler(object sender, MarketData newData)
        {
            callback.PriceChange(newData);
        }

    }

}

