using JsonProjectBE.Controllers;
using JsonProjectBE.DBRepo;
using JsonProjectBE.Models;
using JsonProjectBE.Services;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json.Linq;
using Polly;
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
            var mock_pokemon_service = new Mock<PokemonService>(mock_http_client.Object);
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage { StatusCode = HttpStatusCode.InternalServerError };
            var response_task=Task.FromResult(httpResponseMessage);
            mock_pokemon_service.Setup(p => p.GetPokeInfoAsync("https://pokeapi.co/api/v9/pokemon/dgnfñagfkbdabgfkiasg")).Returns(response_task);
            await mock_pokemon_service.Object.TestRetry("https://pokeapi.co/api/v9/pokemon/dgnfñagfkbdabgfkiasg");
            var invocations = mock_pokemon_service.Invocations.Count();
            //4 because the TestRetryCall count as an invocation
            Assert.True(invocations == 4);
        }
    }

    
}