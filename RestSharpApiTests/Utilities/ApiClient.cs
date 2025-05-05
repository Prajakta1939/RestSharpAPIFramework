using RestSharp;
using System;

namespace RestSharpApiTests.Utilities
{
    public class ApiClient
    {
        private readonly RestClient _client;

        public ApiClient(string baseUrl)
        {
            _client = new RestClient(new RestClientOptions(baseUrl));
        }

        public RestResponse SendPostRequest(string resource, object body)
        {
            var request = new RestRequest(resource, Method.Post);
            request.AddJsonBody(body);
            return _client.Execute(request);
        }

        public RestResponse SendGetRequest(string resource)
        {
            var request = new RestRequest(resource, Method.Get);
            return _client.Execute(request);
        }
    }
}
