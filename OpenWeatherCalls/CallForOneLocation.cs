using RestSharp;
using System;
using System.Configuration;

namespace OpenWeatherCalls
{
    public class CallForOneLocation
    {
        private string urlForOneLocation = ConfigurationManager.AppSettings["BaseUrlForOneLocation"];
        private string key = ConfigurationManager.AppSettings["AppID"]; 

        IRestClient _client = new RestClient
        {
        };

        public string GetWeatherByCityName(string cityName)
        {
            _client.BaseUrl = new Uri(urlForOneLocation + "q="+ cityName + "&APPID=" + key);
            var request = new RestRequest(Method.GET);
            IRestResponse response = _client.Execute(request);
            return response.Content;
        }

        public string GetStatusCodeByCityName(string cityName)
        {
            _client.BaseUrl = new Uri(urlForOneLocation + "q=" + cityName + "&APPID=" + key);
            var request = new RestRequest(Method.GET);
            IRestResponse response = _client.Execute(request);
            return response.StatusCode.ToString();
        }

        public string GetWeatherByID(string id)
        {
            _client.BaseUrl = new Uri(urlForOneLocation + "id=" + id + "&APPID=" + key);
            var request = new RestRequest(Method.GET);
            IRestResponse response = _client.Execute(request);
            return response.Content;
        }
    }
}
