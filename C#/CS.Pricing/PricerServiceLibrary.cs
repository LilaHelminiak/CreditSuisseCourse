﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using CS.Market;

namespace CS.Pricing
{
    [ServiceContract(Namespace = "PricerServiceLibrary", SessionMode = SessionMode.Required, CallbackContract = typeof(IPricerClientContract))]
    public interface IPricerContract
    {
        [OperationContract(IsOneWay = false, IsInitiating = true)]
        void Subscribe();
        [OperationContract(IsOneWay = false, IsTerminating = true)]
        void Unsubscribe();
        [OperationContract(IsOneWay = true)]
        void PublishUIData(OptionData optionData);
    }

    public interface IPricerClientContract
    {
        [OperationContract(IsOneWay = true)]
        void GetMarketData(OptionData newData);
    }



    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class PricerService : IPricerContract
    {
        public static event PricerDataChangeEventHandler PricerDataChangeEvent;
        public delegate void PricerDataChangeEventHandler(object sender, OptionData optionData);

        IPricerClientContract callback = null;

        PricerDataChangeEventHandler pricerChangeHandler = null;

        //Clients call this service operation to subscribe.
        //A price change event handler is registered for this client instance.

        public void Subscribe()
        {
            callback = OperationContext.Current.GetCallbackChannel<IPricerClientContract>();
            pricerChangeHandler = new PricerDataChangeEventHandler(PricerChangeHandler);
            PricerDataChangeEvent += pricerChangeHandler;
        }

        //Clients call this service operation to unsubscribe.
        //The previous price change event handler is deregistered.

        public void Unsubscribe()
        {
            PricerDataChangeEvent -= pricerChangeHandler;
        }

        //Information source clients call this service operation to report a price change.
        //A price change event is raised. The price change event handlers for each subscriber will execute.

        public void PublishUIData(OptionData optionData)
        {
            PricerDataChangeEvent(this, optionData);
        }

        //This event handler runs when a PriceChange event is raised.
        //The client's PriceChange service operation is invoked to provide notification about the price change.

        public void PricerChangeHandler(object sender, OptionData optionData)
        {
            callback.GetMarketData(optionData);
        }

    }
}