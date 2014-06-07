using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using CS.Market;

namespace DataGeneratorServiceLibrary
{

    [ServiceContract]
    interface IDataGeneratorService
    {
        [OperationContract]
        MarketData GetData();
    }

    [DataContract]
    public class MarketData: IMarketData
    {
        [DataMember]
        public DateTime Time { get; set; }
        [DataMember]
        public double StockPrice { get; set; }
        [DataMember]
        public double ImpliedVolatility { get; set; }
    }
}
