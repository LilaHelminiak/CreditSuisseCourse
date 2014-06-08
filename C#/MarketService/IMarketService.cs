using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace MarketServiceLibrary
{
    class IMarketService
    {
        [ServiceContract(Namespace = "MarketService", SessionMode = SessionMode.Required, CallbackContract = typeof(ISampleClientContract))]
        public interface ISampleContract
        {
            [OperationContract(IsOneWay = false, IsInitiating = true)]
            void Subscribe();
            [OperationContract(IsOneWay = false, IsTerminating = true)]
            void Unsubscribe();
            [OperationContract(IsOneWay = true)]
            void PublishPriceChange(MarketData newData);
        }

        public interface ISampleClientContract
        {
            [OperationContract(IsOneWay = true)]
            void PriceChange(MarketData newData);
        }
    }
}
