using Newtonsoft.Json.Linq;

namespace JsonProjectBE.Services
{
    public interface IPokemonService
    {

        public Task<JObject> GetPokeInfoAsync(String name);
    }
}
