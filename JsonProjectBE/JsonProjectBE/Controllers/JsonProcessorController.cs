using Microsoft.AspNetCore.Mvc;
using JsonProjectBE.DBRepo;
using Newtonsoft.Json.Linq;

namespace JsonProjectBE.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
            try
            {
                //if(userHandler.ValidateUserId(userHanlder.GetUserById(data["customerId"])))
                    // mongoDbService.Store(CustomerJsonHandler.Treat(data).ToString())
                
            }
            catch
            {
                

            }
            var data = request.Data.SelectTokens("$..Products[?(@.Price >= 50)].Name"); 

            //if (_db.asyncStoreJson(data.ToString()).IsCompletedSuccessfully)
            if (_db.AsyncStoreJson(data.ToString()).IsCompletedSuccessfully)
            {
                return new response { message = "Document saved succesfully", status = "OK" };
            }
            else
            {
                return new response { message = "Document not saved", status = "FAILED" };

            }
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
    "cliendId": "string",
    "data": {
                "VAT"= "string
            }
}
*/