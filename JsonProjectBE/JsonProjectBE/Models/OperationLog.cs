using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace JsonProjectBE.Models
{
    public class OperationLog
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public ObjectId _id { get; set; }
        public string userid { get; set; }
        public TimeSpan date { get; set; }
        public string name { get; set; }
        public int size { get; set; }
    }
}
