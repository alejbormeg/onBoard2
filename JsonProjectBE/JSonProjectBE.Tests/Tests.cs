using JsonProjectBE.Controllers;
using JsonProjectBE.DBRepo;
using JsonProjectBE.Models;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json.Linq;
using static JsonProjectBE.Controllers.JsonProcessorController;

namespace JSonProjectBE.Tests
{
    public class Tests
    {
        [Fact]
        public async Task TestingPost()
        {
            JObject data=new JObject();
            data.Add("data", JObject.Parse(@"{'operationID':""7887"",'VAT':""89867""}"));
            var request = new Request
            {
                ClientId = "client_1",
                Data = data
            };
            var logger = new Mock<ILogger<JsonProcessorController>>();
            var mongo = new Mongo();
            JsonProcessorController controller = new JsonProcessorController(logger.Object, mongo);

            response expected_response = new response { message = "Document saved succesfully", status = "OK" };

            String expectedString = expected_response.message;
            String result = controller.Post(request).Result.message;
            Assert.Equal(expectedString,result);
        }
    }
}