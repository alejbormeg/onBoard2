using Microsoft.AspNetCore.Mvc;
using JsonProjectBE.DBRepo;
using JsonProjectBE.Models;
using JsonProjectBE.Services;
using Newtonsoft.Json.Linq;

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
        private IPokemonService _pokemonService;

        public PkmController(ILogger<PkmController> logger, Mongo db, IPokemonService pokemonService)
        {
            _db = db;
            _logger = logger;
            _pokemonService = pokemonService;
        }

        // resultProperty: "data_1", accessor: $.Data1[3].data_1
        //var data = request.Data.SelectTokens("$..Products[?(@.Price >= 50)].Name"); 
        [HttpPost(Name = "PkmUpload")]
        public async Task<response> Post([FromBody] Models.Request request)
        {
            JsonHandler _handler = new JsonHandler();
            
            List<String> fields = _db.AsyncGetClientRequirements(request.ClientId);
            PokemonDocument data = _handler.CreateBasePkmDocument(request, fields);
            JObject fullPkmInfo = await _pokemonService.GetPokeInfoAsync(data.Data.GetElement(fields[0]).Value.ToString());


            if (_db.AsyncStorePkmDocument(data).IsCompletedSuccessfully)
            {
                return new response { message = "Document saved succesfully", status = "OK" };
            }
            else
            {
                return new response { message = "Document not saved", status = "FAILED" };

            }
        }
    }
}