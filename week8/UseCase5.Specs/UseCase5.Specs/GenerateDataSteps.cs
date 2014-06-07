using NUnit.Framework;
using TechTalk.SpecFlow;
using UseCase5.Specs.DataGeneratorReference;

namespace UseCase5.Specs
{
    [Binding]
    public class GenerateDataSteps
    {

        [Given]
        public void Given_I_connect_to_Data_Generator_Service()
        {
            var client = new DataGeneratorServiceClient();
            ScenarioContext.Current.Set(client, "client");
            Assert.AreEqual(System.ServiceModel.CommunicationState.Created, client.State);
        }
        
        [When]
        public void When_I_retrive_generated_data()
        {
            var client = (DataGeneratorServiceClient) ScenarioContext.Current["client"];
            var generatedData = client.GetData();
            FeatureContext.Current.Set(generatedData, "generatedData");
            Assert.IsNotNull(generatedData);
        }
        
        [Then]
        public void Then_I_get_stock_price()
        {
            var generatedData = (MarketData) FeatureContext.Current["generatedData"];
            Assert.IsNotNull(generatedData.StockPrice);
        }
        
        [Then]
        public void Then_I_get_business_date_and_time()
        {
            var generatedData = (MarketData)FeatureContext.Current["generatedData"];
            Assert.IsNotNull(generatedData.Time);
        }
    }
}
