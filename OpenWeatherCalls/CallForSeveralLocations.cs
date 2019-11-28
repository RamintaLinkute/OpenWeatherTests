using RestSharp;
using System;
using System.Configuration;

namespace OpenWeatherCalls
{
    public class CallForSeveralLocations
    {
        private string urlForSeveralLocation = ConfigurationManager.AppSettings["BaseUrlForOneSeveralLocations"];
        private string key = ConfigurationManager.AppSettings["AppID"];

        IRestClient _client = new RestClient
        {
        };

        public string GetWeatherByIDs(string ids)
        {
            _client.BaseUrl = new Uri(urlForSeveralLocation + "id=" + ids + "&APPID=" + key);
            var request = new RestRequest(Method.GET);
            IRestResponse response = _client.Execute(request);
            return response.Content;
        }

        public string GetStatusCodeByIDs(string ids)
        {
            _client.BaseUrl = new Uri(urlForSeveralLocation + "id=" + ids + "&APPID=" + key);
            var request = new RestRequest(Method.GET);
            IRestResponse response = _client.Execute(request);
            return response.StatusCode.ToString();
        }
    }
}
