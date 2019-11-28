using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using OpenWeatherCalls;
using TechTalk.SpecFlow;

namespace OpenWeatherAPITests
{
    [Binding]
    public class CallCurrentWeatherDataForSeveralCitiesSteps
    {
        private CallForSeveralLocations callForSeveralLocations = new CallForSeveralLocations();
        private string ids;
        private string content;
        private int amount;
        private string message;
        private string statusCode;

        [Given(@"IDs '(.*)' exists in the system")]
        public void GivenIDsExistsInTheSystem(string cityIDs)
        {
            ids = cityIDs.Replace(' ', ',');
        }
        
        [When(@"I request to get the weather data by ids")]
        public void WhenIRequestToGetTheWeatherDataByIds()
        {
            content = callForSeveralLocations.GetWeatherByIDs(ids);
            statusCode = callForSeveralLocations.GetStatusCodeByIDs(ids);
        }
        
        [Then(@"Count '(.*)' is returned in the response")]
        public void ThenCountIsReturnedInTheResponse(int amountOfCities)
        {
            var jObject = JObject.Parse(content);
            amount = int.Parse(jObject.GetValue("cnt").ToString());
            Assert.AreEqual(amountOfCities, amount);
        }
        
        [Then(@"Message '(.*)' is returned in the response")]
        public void ThenMessageIsReturnedInTheResponse(string expectedMessage)
        {
            var jObject = JObject.Parse(content);
            message = jObject.GetValue("message").ToString();
            Assert.AreEqual(expectedMessage, message);
        }

        [Then(@"the status code '(.*)' is returned in the response")]
        public void ThenTheStatusCodeIsReturnedInTheResponse(string expectedStatusCode)
        {
            Assert.AreEqual(expectedStatusCode, statusCode);
        }
    }
}
