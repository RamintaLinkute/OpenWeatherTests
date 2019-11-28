using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using OpenWeatherCalls;
using TechTalk.SpecFlow;

namespace OpenWeatherAPITests
{
    [Binding]
    public class CallCurrentWeatherDataForOneLocationSteps
    {
        private CallForOneLocation callForOneLocation = new CallForOneLocation();
        private string city;
        private string country;
        private string cityId;
        private string responseContent;
        private string responseStatusCode;
        private string descprition;

        [Given(@"City '(.*)' exists in the system")]
        public void GivenCityExistsInTheSystem(string cityName)
        {
            city = cityName;
        }

        [When(@"I request to get the weather data by city")]
        public void WhenIRequestToGetTheWeatherDataByCity()
        {
            responseContent = callForOneLocation.GetWeatherByCityName(city);
            responseStatusCode = callForOneLocation.GetStatusCodeByCityName(city);
        }

        [Then(@"City '(.*)' is returned in the response")]
        public void ThenCityIsReturnedInTheResponse(string expectedCity)
        {
            var jObject = JObject.Parse(responseContent);
            city = jObject.GetValue("name").ToString();
            Assert.AreEqual(expectedCity, city);
        }

        [Given(@"City '(.*)' does not exist in the system")]
        public void GivenCityDoesNotExistInTheSystem(string notExistingCityName)
        {
            city = notExistingCityName;
        }

        [Given(@"country code '(.*)' exists in the system")]
        public void GivenCountryCodeExistsInTheSystem(string countryCode)
        {
            country = countryCode;
        }

        [When(@"I request to get the weather data by city and country code")]
        public void WhenIRequestToGetTheWeatherDataByCityAndCountryCode()
        {
            responseContent = callForOneLocation.GetWeatherByCityName(city + "," + country);
            responseStatusCode = callForOneLocation.GetStatusCodeByCityName(city + "," + country);
        }

        [Given(@"country code '(.*)' does not exist in the system")]
        public void GivenCountryCodeDoesNotExistInTheSystem(string notExistingCountrycode)
        {
            country = notExistingCountrycode;
        }

        [Given(@"ID '(.*)' exists in the system")]
        public void GivenIDExistsInTheSystem(int id)
        {
            cityId = id.ToString();
        }

        [When(@"I request to get the weather data by id")]
        public void WhenIRequestToGetTheWeatherDataById()
        {
            responseContent = callForOneLocation.GetWeatherByID(cityId);
        }

        [Then(@"status code '(.*)' is returned in the response")]
        public void ThenStatusCodeIsReturnedInTheResponse(string expectedStatusCode)
        {
           Assert.AreEqual(expectedStatusCode, responseStatusCode);
        }

        [Then(@"description '(.*)' is returned in the response")]
        public void ThenDescriptionIsReturnedInTheResponse(string expctedDescription)
        {
            var jObject = JObject.Parse(responseContent);
            city = jObject.GetValue("description").ToString();
            Assert.AreEqual(expctedDescription, responseStatusCode);
        }

    }
}
