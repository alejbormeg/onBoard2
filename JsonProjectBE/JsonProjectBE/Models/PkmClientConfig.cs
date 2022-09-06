using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace JsonProjectBE.Models
{
    public class PkmClientConfig
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public ObjectId _id { get; set; }
        public string clientId { get; set; }
        public string nameLocation { get; set; }
        public string nameDisplay { get; set; }
    }
}
