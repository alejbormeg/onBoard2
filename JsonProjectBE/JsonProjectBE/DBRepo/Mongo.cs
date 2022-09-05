using MongoDB.Driver;
using MongoDB.Bson;
using JsonProjectBE.Handlers;

using JsonProjectBE.Models;
using MongoDB.Bson.Serialization;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace JsonProjectBE.DBRepo
{
    public class Mongo : IDBRepo
    {
        //private IMongoCollection<Document> _documentCollection;
        private IMongoCollection<PokemonDocument> _PokemonDocumentCollection;
        private IMongoCollection<OperationLog> _logCollection;
        //private IMongoCollection<ClientConfig> _ClientConfigCollection;
        private IMongoCollection<PkmClientConfig> _PkmClientConfigCollection;

        public Mongo()
        {
            var mongoClient = new MongoClient("mongodb://admin:2yqOCeggHXPp@mongodb.dev.inputforyou.local:27017/?ssl=false");
            var mongoDatabase = mongoClient.GetDatabase("onBoard2");
            //_documentCollection = mongoDatabase.GetCollection<Document>("Document");
            _PokemonDocumentCollection = mongoDatabase.GetCollection<PokemonDocument>("Document");
            _logCollection = mongoDatabase.GetCollection<OperationLog>("OperationLog");
            //_ClientConfigCollection = mongoDatabase.GetCollection<ClientConfig>("ClientConfig");
            _PkmClientConfigCollection = mongoDatabase.GetCollection<PkmClientConfig>("ClientConfig");
        }

        public Task AsyncStoreDocument(Document document)
        {
            //_documentCollection.InsertOneAsync(document);
            return Task.CompletedTask;
        } 
        public List<String> AsyncGetWantedFields( string clientId )
        {
            //var _client = _ClientConfigCollection.Find(x => x.clientId == clientId).FirstOrDefaultAsync();
            List<String> fields = new List<String>();
            //foreach ( String field in _client.Result.wantedFields)
            //{
            //    fields.Add(field);
            //}
            return fields;
        }

        public Task AsyncStorePkmDocument(PokemonDocument document)
        {
            _PokemonDocumentCollection.InsertOneAsync(document);
            return Task.CompletedTask;
        }
        public List<String> AsyncGetClientRequirements(string clientId)
        {
            var _client = _PkmClientConfigCollection.Find(x => x.clientId == clientId).FirstOrDefaultAsync();
            List<String> fields = new List<String>();
            fields.Add(_client.Result.nameDisplay);
            fields.Add(_client.Result.nameLocation);
            return fields;
        }

        public Task AsyncStoreJson(JObject data)
        {
            throw new NotImplementedException();
        }
            //Document document = new Document
            //{
            //    originalFile = JObject.Parse(data),
            //    extractedFile = JObject.Parse(data),
            //    date = DateTime.Now.TimeOfDay,
            //    ClientId = "Pedro Melenas"
            //};
            //return _ClientConfigCollection.


        /// <summary>
        /// Store the content in MongoDB and logs the process 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        //public Task AsyncStoreJson(JObject data)
        //{
        //    String dataSave = data.ToString();
        //    //Dictionary<string, string> dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(data);           
        //    Document document = new Document
        //    {
        //        originalFile = data,
        //        extractedFile = data,
        //        date = DateTime.Now.TimeOfDay,
        //        ClientId = "Pedro Melenas"
        //    };
        //    _documentCollection.InsertOneAsync(document);

        //    return Task.CompletedTask; 
        //}
        //---------------------------------------------------------------
    }
}
