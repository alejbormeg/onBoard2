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
            foreach ( var field in fields)
            {
                extracted.Add(field, request.Data[field]?.ToString());
            }
            document.extractedFile = BsonDocument.Parse( extracted.ToString() );
            return document;
        }

        public PokemonDocument CreateBasePkmDocument(Request request, List<string> location)
        {
            PokemonDocument document = new PokemonDocument();

            document.ClientId = request.ClientId;
            JObject data = new JObject();
            var asdf = request.Data;
            data.Add(location[0], request.Data.SelectToken(location[1])?.ToString() ?? "");
            document.Data = BsonDocument.Parse( data.ToString() );
            return document;
        }
    }
}
