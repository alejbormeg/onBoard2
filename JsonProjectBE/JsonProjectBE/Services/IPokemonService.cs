using Newtonsoft.Json.Linq;

namespace JsonProjectBE.Services
{
    public interface IPokemonService
    {
        public JObject GetPokeInfo(String name);

    }
}
