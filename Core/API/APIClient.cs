using RestSharp;
using System.Text.RegularExpressions;

namespace SampleAPITestProject.Core.API
{
    public class APIClient
    {
        private RestClient client;
        private string baseURL = "";

        public APIClient() { }

        public void SetBaseURL(string newURL)
        {
            if (IsValidUrl(newURL))
            {
                baseURL = newURL;
                var options = new RestClientOptions(baseURL);
                client = new RestClient(options);
            }
            else
            {
                throw new Exception($"Invalid URL format.\nURL: {newURL}");
            }
        }

        public RestResponse ExecuteRequest(string endpoint, Method method = Method.Get, Dictionary<string, string> queryParams = null, object bodyPayload = null)
        {
            if (client == null)
            {
                if (!string.IsNullOrWhiteSpace(baseURL))
                {
                    var options = new RestClientOptions(baseURL);
                    client = new RestClient(options);
                }
                else
                {
                    throw new InvalidOperationException("API client is not initialized. Call SetBaseURL() first.");
                }
            }

            var request = new RestRequest(endpoint, method);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");

            if (queryParams != null)
            {
                foreach (var param in queryParams)
                {
                    request.AddQueryParameter(param.Key, param.Value);
                }
            }

            if (bodyPayload != null && (method == Method.Post || method == Method.Put || method == Method.Patch))
            {
                request.AddJsonBody(bodyPayload);
            }

            return client.Execute(request);
        }

        public string GetBaseURL()
        {
            return baseURL;
        }

        private bool IsValidUrl(string url)
        {
            string pattern = @"^(https?:\/\/)?([a-zA-Z0-9.-]+)\.([a-zA-Z]{2,6})(\/\S*)?$";
            return Regex.IsMatch(url, pattern, RegexOptions.IgnoreCase);
        }
    }
}
