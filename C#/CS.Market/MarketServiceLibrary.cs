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

        public void Subscribe()
        {
            callback = OperationContext.Current.GetCallbackChannel<IMarketClientContract>();
            marketChangeHandler = new MarketDataChangeEventHandler(MarketChangeHandler);
            MarketDataChangeEvent += marketChangeHandler;
        }

        public void Unsubscribe()
        {
            MarketDataChangeEvent -= marketChangeHandler;
        }

        public void PublishMarketData(MarketData newData)
        {
            if (MarketDataChangeEvent != null)
            {
                MarketDataChangeEvent(this, newData);
            }
        }

        public void MarketChangeHandler(object sender, MarketData newData)
        {
            callback.GetMarketData(newData);
        }

    }
}
