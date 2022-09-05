using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace JsonProjectBE.Models
{
    public class ClientConfig
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public ObjectId _id { get; set; }
        public string clientId { get; set; }
        public List<string> wantedFields { get; set; }
    }
}
