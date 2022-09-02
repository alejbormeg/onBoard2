using JsonProjectBE.Models;
using Newtonsoft.Json.Linq;
using JsonProjectBE.DBRepo;

namespace JsonProjectBE.Handlers
{
    public class JsonHandler
    {
        public Document Transform(Request request)
        {
            Document document = new Document();

            //document.date = DateTime.Now.TimeOfDay;
            ////ClientID
            //document.ClientId = request.CliendId;
            ////timespan

            return document;
        }
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
