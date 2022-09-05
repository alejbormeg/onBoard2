using JsonProjectBE.Controllers;
using JsonProjectBE.DBRepo;
using JsonProjectBE.Models;
using JsonProjectBE.Services;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json.Linq;
using System.Net;
using static JsonProjectBE.Controllers.JsonProcessorController;

namespace JSonProjectBE.Tests
{
    public class Tests
    {
        [Fact]
        public async Task TestingPost()
        {
            JObject data=new JObject();

            data.Add("data", JObject.Parse(@"{'dedication':""sport clothes"",'prices':""medium"",'quality':""high""}"));
            var request = new Request
            {
                ClientId = "adidas",
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

        [Fact]
        public async Task TestingRetry()
        {
            var mock_http_client = new Mock<HttpClient>();
            var task = new Mock<Task<HttpResponseMessage>>();
            task.Setup(x => x.Result).Returns(new HttpResponseMessage(HttpStatusCode.BadRequest));
            //Change the get async behaviour
            mock_http_client.Setup(p => p.GetAsync("https://pokeapi.co/api/v2/pokemon/ditto")).Returns();

        }
    }

    
}