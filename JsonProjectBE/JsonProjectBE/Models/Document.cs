using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json.Linq;

namespace JsonProjectBE.Models
{
    public class Document
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)] 
        public ObjectId _id { get; set; }
        public JObject originalFile { get; set; }
        public JObject extractedFile { get; set; }
        public TimeSpan date { get; set; }
        public string user { get; set; }
    }
}
