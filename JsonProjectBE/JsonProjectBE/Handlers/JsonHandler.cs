using JsonProjectBE.Models;
using Newtonsoft.Json.Linq;
using JsonProjectBE.DBRepo;
using MongoDB.Bson;

namespace JsonProjectBE.Handlers
{
    public class JsonHandler
    {
        public Document CraftBaseDocument(Request request, List<String> fields)
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

    }
}
