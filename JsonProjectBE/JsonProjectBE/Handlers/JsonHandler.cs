using JsonProjectBE.Models;
using Newtonsoft.Json.Linq;
using JsonProjectBE.DBRepo;
namespace JsonProjectBE.Handlers
{
    public class JsonHandler
    {
        //public Request Request { get; set; }
        //public JsonHandler(Request request)
        //{
        //    Request = request;
        //}

        public Mongo _db { get; set; }

        public async JObject Transform( Request request)
        {
            //    var client = "client1";
            //    request.CliendId
            //    Document document = new Document();
            //    //save original json
            //    JObject originalJson = requestToJson(request);
            //    document.originalFile= originalJson;
            //    //create new json with original json
            //    if( client == request.CliendId)
            //    {
            //        //var wantedData = request.Data.SelectToken("Data.VAT");
            //        var wantedData = request.Data.SelectToken("$.VAT");
            //        document.extractedFile = (JObject)wantedData;
            //    }
            //    document.date = DateTime.Now.TimeOfDay;
            //    //ClientID
            //    document.ClientId = request.CliendId;
            //    //timespan
            return new JObject();
        }

        public async JObject requestToJson( Request request )
        {
            
        }

}
