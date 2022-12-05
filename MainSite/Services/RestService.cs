using MainSite.Options;
using Microsoft.Extensions.Options;
using RestSharp;

namespace MainSite.Services
{
    public interface IRestService
    {
        public Task<string> ProcessRequest(string urlStub, Method method);
        public Task<T> ProcessRequest<T>(string urlStub, Method method);
    }

    public class RestService : IRestService
    {
        private readonly CDNOptions _options;
        private readonly RestClient _client;
        
        public RestService(IOptions<CDNOptions> options)
        {
            _options = options.Value;
            _client = new RestClient(_options.BaseUrl);
        }

        public async Task<T> ProcessRequest<T>(string urlStub, Method method)
        {
            var request = new RestRequest(urlStub, method);
            var response = await _client.GetAsync<T>(request);

            return response;
        }

        public async Task<string> ProcessRequest(string urlStub, Method method)
        {
            var request = new RestRequest(urlStub, method);
            var response = await _client.GetAsync(request);

            return response.Content;
        }
    }
}
