using System;
using NUnit.Framework;
using TechTalk.SpecFlow;
using UseCase5.Specs.DataGeneratorReference;

namespace UseCase5.Specs
{
    [Binding]
    public class UpdateMarketDataSteps
    {
        [Given]
        public void Given_Generated_data_by_Data_Generator_Service()
        {
            var generatedData = (MarketData) FeatureContext.Current["generatedData"];
            Assert.IsNotNull(generatedData);
        }

        [Given]
        public void Given_Market_with_data_before_the_update()
        {
            var market = new Market();
            ScenarioContext.Current.Set(market, "market");
            Assert.AreEqual(DateTime.MinValue, market.Time);
            Assert.AreEqual(0, market.StockPrice);
        }
        
        [When]
        public void When_Market_updates_the_data()
        {
            var market = (Market) ScenarioContext.Current["market"];
            var generatedData = (MarketData)FeatureContext.Current["generatedData"];
            var updated = market.Update(generatedData.Time, generatedData.StockPrice);
            Assert.IsTrue(updated);
        }

        [Then]
        public void Then_Stock_price_is_updated()
        {
            var market = (Market)ScenarioContext.Current["market"];
            Assert.IsNotNull(market.StockPrice);
        }
        
        [Then]
        public void Then_Business_date_and_time_is_updated()
        {
            var market = (Market)ScenarioContext.Current["market"];
            Assert.AreNotEqual(DateTime.MinValue, market.Time);
        }
    }
}
