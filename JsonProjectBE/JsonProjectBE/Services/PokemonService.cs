using Newtonsoft.Json.Linq;

namespace JsonProjectBE.Services
{
    public class PokemonService : IPokemonService
    {
        HttpClient cliente_http;
        public PokemonService()
        {
            cliente_http = new HttpClient();
        }
        public JObject GetPokeInfo(string name)
        {
            throw new NotImplementedException();
        }
    }
}
