using Microsoft.AspNetCore.Mvc;
using JsonProjectBE.DBRepo;
using JsonProjectBE.Models;
using Newtonsoft.Json.Linq;

using JsonProjectBE.Handlers;


namespace JsonProjectBE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    // ---> HTTP Request --> ControllerBase (Http...) --->  [ --> [ActionFilter.onRequest] --> Post() --> [ActionFilter.onRequested] --> ] ---> HttResponse
    public class JsonProcessorController : ControllerBase
    {
        // LEAN DomainDrivenDevelopment

        private readonly ILogger<JsonProcessorController> _logger;
        private IDBRepo _db;

        public JsonProcessorController(ILogger<JsonProcessorController> logger, Mongo db)
        {
            _db = db;
            _logger = logger;
        }

        // resultProperty: "data_1", accessor: $.Data1[3].data_1
        [HttpPost(Name = "PostJsonProcessor")]
        public async Task<response> Post([FromBody] Models.Request request)
        {
            //var data = _handler.CrafBaseDocument(request);

            //var customerSchema = _db.Customer.GetSchema(data.ClientId);

            JsonHandler _handler = new JsonHandler();

            List<String> fields = _db.AsyncGetWantedFields(request.ClientId);
            //RETURN A DOCUMENT
            var data = _handler.CraftBaseDocument(request, fields);

            //STORE DOCUMENT UN MONGODB
            if (_db.AsyncStoreDocument(data).IsCompletedSuccessfully)
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