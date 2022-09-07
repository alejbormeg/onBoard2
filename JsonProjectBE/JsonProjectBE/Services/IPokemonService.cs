using Newtonsoft.Json.Linq;

namespace JsonProjectBE.Services
{
    public interface IPokemonService
    {
        public Task<HttpResponseMessage> GetPokeInfoAsync(String name);

    }
}
