using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;


namespace CS.Market
{
    [ServiceContract(Namespace = "MarketServiceLibrary", SessionMode = SessionMode.Required, CallbackContract = typeof(IMarketClientContract))]
    public interface IMarketContract
    {
        [OperationContract(IsOneWay = false, IsInitiating = true)]
        void Subscribe();
        [OperationContract(IsOneWay = false, IsTerminating = true)]
        void Unsubscribe();
        [OperationContract(IsOneWay = true)]
        void PublishMarketData(MarketData newData);
    }

    public interface IMarketClientContract
    {
        [OperationContract(IsOneWay = true)]
        void GetMarketData(MarketData newData);
    }



    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class MarketService : IMarketContract
    {
        public static event MarketDataChangeEventHandler MarketDataChangeEvent;
        public delegate void MarketDataChangeEventHandler(object sender, MarketData newData);

        IMarketClientContract callback = null;

        MarketDataChangeEventHandler marketChangeHandler = null;

        //Clients call this service operation to subscribe.
        //A price change event handler is registered for this client instance.

        public void Subscribe()
        {
            callback = OperationContext.Current.GetCallbackChannel<IMarketClientContract>();
            marketChangeHandler = new MarketDataChangeEventHandler(MarketChangeHandler);
            MarketDataChangeEvent += marketChangeHandler;
        }

        //Clients call this service operation to unsubscribe.
        //The previous price change event handler is deregistered.

        public void Unsubscribe()
        {
            MarketDataChangeEvent -= marketChangeHandler;
        }

        //Information source clients call this service operation to report a price change.
        //A price change event is raised. The price change event handlers for each subscriber will execute.

        public void PublishMarketData(MarketData newData)
        {
            MarketDataChangeEvent(this, newData);
        }

        //This event handler runs when a PriceChange event is raised.
        //The client's PriceChange service operation is invoked to provide notification about the price change.

        public void MarketChangeHandler(object sender, MarketData newData)
        {
            callback.GetMarketData(newData);
        }

    }
}
