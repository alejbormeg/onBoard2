namespace JSonProjectBE.Tests
{
    public class Tests
    {
        [Fact]
        public void Test1()
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

        }
    }
}