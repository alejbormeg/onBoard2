using JsonProjectBE.Models;
using Newtonsoft.Json.Linq;
using JsonProjectBE.DBRepo;
using MongoDB.Bson;

namespace JsonProjectBE.Handlers
{
    public class JsonHandler
    {
        public Document CrafBaseDocument(Request request)
        {
            Document document = new Document();

            document.ClientId = request.ClientId;
            document.date = DateTime.Now.TimeOfDay;
            document.originalFile = BsonDocument.Parse( request.Data.ToString() );

            JObject extracted= new JObject();
            extracted.Add("prices", request.Data["prices"]?.ToString());

            document.extractedFile = BsonDocument.Parse( extracted.ToString() );
            return document;
        }

        //public BsonDocument TransformForCustomerSchema()
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

    }
}
