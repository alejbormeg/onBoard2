using Microsoft.AspNetCore.Mvc;
using JsonProjectBE.DBRepo;
using Newtonsoft.Json.Linq;

using JsonProjectBE.Handlers;


namespace JsonProjectBE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    // ---> HTTP Request --> ControllerBase (Http...) --->  [ --> [ActionFilter.onRequest] --> Post() --> [ActionFilter.onRequested] --> ] ---> HttResponse
    public class JsonProcessorController : ControllerBase
    {
        public class response
        {
            public string message { get; set; }
            public string status { get; set; }
        }

        // LEAN DomainDrivenDevelopment

        private readonly ILogger<JsonProcessorController> _logger;
        private IDBRepo _db;

        public JsonProcessorController(ILogger<JsonProcessorController> logger, Mongo db)
        {
            _db = db;
            _logger = logger;
        }

        [HttpPost(Name = "PostJsonProcessor")]
        public async Task<response> Post([FromBody] Models.Request request)
        {
            //var data = _handler.CrafBaseDocument(request);

            //var customerSchema = _db.Customer.GetSchema(data.ClientId);

            JsonHandler _handler = new JsonHandler();

            List<String> fields = _db.AsyncGetWantedFields( request.ClientId );
            //RETURN A DOCUMENT
            var data = _handler.CraftBaseDocument(request, fields);

            //STORE DOCUMENT UN MONGODB
            if ( _db.AsyncStoreDocument(data).IsCompletedSuccessfully )
            {
                return new response { message = "Document saved succesfully", status = "OK" };
            }
            else
            {
                return new response { message = "Document not saved", status = "FAILED" };

            }

            //var data = request.Data.SelectTokens("$..Products[?(@.Price >= 50)].Name"); 
            //if (_db.asyncStoreJson(data.ToString()).IsCompletedSuccessfully)
            //if (_db.AsyncStoreJson(data.ToString()).IsCompletedSuccessfully)


            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = Random.Shared.Next(-20, 55),
            //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            //})
            //.ToArray();
        }
    }
}




/*    
{
    "cliendId": "cli1",
    "data": {
                "VAT"= {}
                "pokemons"=[]
                "operationid"="string"
            }
}
*/