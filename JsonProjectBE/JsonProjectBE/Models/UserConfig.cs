using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace JsonProjectBE.Models
{
    public class UserConfig
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public ObjectId _id { get; set; }
        public string userId { get; set; }
        public string wantedField { get; set; }
    }
}
