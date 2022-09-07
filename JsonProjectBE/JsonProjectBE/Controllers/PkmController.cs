using Microsoft.AspNetCore.Mvc;
using JsonProjectBE.DBRepo;
using JsonProjectBE.Models;
using Newtonsoft.Json.Linq;
using JsonProjectBE.Services;
using JsonProjectBE.Handlers;


namespace JsonProjectBE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    // ---> HTTP Request --> ControllerBase (Http...) --->  [ --> [ActionFilter.onRequest] --> Post() --> [ActionFilter.onRequested] --> ] ---> HttResponse
    public class PkmController : ControllerBase
    {

        // LEAN DomainDrivenDevelopment

        private readonly ILogger<PkmController> _logger;
        private IDBRepo _db;
        private PokemonService _pokeService;
        public PkmController(ILogger<PkmController> logger, Mongo db, PokemonService pokemon)
        {
            _db = db;
            _logger = logger;
            _pokeService = pokemon;
        }

        // resultProperty: "data_1", accessor: $.Data1[3].data_1
        //var data = request.Data.SelectTokens("$..Products[?(@.Price >= 50)].Name"); 
        [HttpPost(Name = "PkmUpload")]
        public async Task<response> Post([FromBody] Models.Request request)
        {
            _pokeService.TestRetry("https://pokeapi.co/api/v2/pokemon/diaskdnfvlgg");
            return new response { message = "Document saved succesfully", status = "OK" };
        }
    }
}