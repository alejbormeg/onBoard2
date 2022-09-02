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
        private IMongoCollection<Document> _documentCollection;
        private IMongoCollection<OperationLog> _logCollection;
        private IMongoCollection<UserConfig> _userCollection;

        public Mongo()
        {
            var mongoClient = new MongoClient("mongodb://admin:2yqOCeggHXPp@mongodb.dev.inputforyou.local:27017/?ssl=false");
            var mongoDatabase = mongoClient.GetDatabase("onBoard2");
            _documentCollection = mongoDatabase.GetCollection<Document>("Document");
            _logCollection = mongoDatabase.GetCollection<OperationLog>("OperationLog");
            _userCollection = mongoDatabase.GetCollection<UserConfig>("UserConfig");
        }

      

        /// <summary>
        /// Store the content in MongoDB and logs the process 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task AsyncStoreJson(JObject data)
        {
            String dataSave = data.ToString();
                      
            Document document = new Document
            {
                originalFile = data,
                extractedFile = data,
                date = DateTime.Now.TimeOfDay,
                ClientId = "Pedro Melenas"
            };
            _documentCollection.InsertOneAsync(document);

            return Task.CompletedTask; 
        }

        public Task AsyncStoreDocument(Document document)
        {
            _documentCollection.InsertOneAsync(document);
            return Task.CompletedTask;
        }

        public async Task<String> AsyncGetRequiredField(string user)
        {
            var _user= await _userCollection.Find(x => x.userId == user).FirstOrDefaultAsync();
            return _user.wantedField;
        }

    }
}
