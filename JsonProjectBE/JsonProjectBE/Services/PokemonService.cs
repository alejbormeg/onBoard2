using Newtonsoft.Json.Linq;
using Polly;
using Polly.Retry;
using System.Net;

namespace JsonProjectBE.Services
{
    public class PokemonService : IPokemonService
    {
        public HttpClient cliente_http;

        public AsyncRetryPolicy<HttpResponseMessage> _policy = Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                                                                     .RetryAsync(3);

        public PokemonService(HttpClient client)
        {
            cliente_http = client;
        }

        public virtual async Task<HttpResponseMessage> GetPokeInfoAsync(string name)
        {

            var response = await cliente_http.GetAsync(name);
            return response;
        }

        public async Task<HttpResponseMessage> TestRetry(String url)
        {
           return await _policy.ExecuteAsync(async () => await GetPokeInfoAsync(url));
        }
    }
}
