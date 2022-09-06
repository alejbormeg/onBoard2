using Newtonsoft.Json.Linq;

namespace JsonProjectBE.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly HttpClient _httpClient;
        private readonly String _url = "https://pokeapi.co/api/v2";
        private readonly String _search = "/pokemon/";
        public PokemonService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<JObject> GetPokeInfoAsync(string name)
        {
            JObject pokemon = new JObject();
            HttpResponseMessage response = await _httpClient.GetAsync( _url + _search + name.ToLower() );
            if (response.IsSuccessStatusCode)
            {
                pokemon = JObject.Parse( await response.Content.ReadAsStringAsync() );
            }
            return pokemon;
        }
    }
}
