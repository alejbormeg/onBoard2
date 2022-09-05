using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json.Linq;

namespace JsonProjectBE.Models
{
    public class PokemonDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public ObjectId _id { get; set; }
        public string ClientId { get; set; }
        public BsonDocument Data { get; set; }
        
    }



    //public interface IStrategy
    //{
    //    object DoAlgorithm(object data);
    //}
    //class ConcreteStrategyA : IStrategy
    //{
    //    public object DoAlgorithm(object data)
    //    {
    //        var list = data as List<string>;
    //        list.Sort();

    //        return list;
    //    }
    //}
    //class ConcreteStrategyB : IStrategy
    //{
    //    public object DoAlgorithm(object data)
    //    {
    //        var list = data as List<string>;
    //        list.Sort();
    //        list.Reverse();

    //        return list;
    //    }
    //}




}
