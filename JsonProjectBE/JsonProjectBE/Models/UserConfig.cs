using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace JsonProjectBE.Models
{
    public class UserConfig
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public ObjectId _id { get; set; }
        public string Name { get; set; }
        public string userid { get; set; }
    }
}
