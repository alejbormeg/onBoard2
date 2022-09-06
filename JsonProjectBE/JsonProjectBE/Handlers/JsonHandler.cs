using JsonProjectBE.Models;
using JsonProjectBE.Services;
using Newtonsoft.Json.Linq;
using JsonProjectBE.DBRepo;
using MongoDB.Bson;
using JsonPatchSample;
using Microsoft.AspNetCore.JsonPatch;
using MongoDB.Bson.IO;

namespace JsonProjectBE.Handlers
{
    public class JsonHandler
    {
        public Document CraftBaseDocument(Request request, List<String> fields)
        {
            Document document = new Document();

            document.ClientId = request.ClientId;
            document.date = DateTime.Now.TimeOfDay;
            document.originalFile = BsonDocument.Parse(request.Data.ToString());

            JObject extracted = new JObject();
            foreach (var field in fields)
            {
                extracted.Add(field, request.Data[field]?.ToString());
            }
            document.extractedFile = BsonDocument.Parse(extracted.ToString());
            return document;
        }

        public PokemonDocument CreateBasePkmDocument(Request request, List<string> location)
        {
            PokemonDocument document = new PokemonDocument();

            document.ClientId = request.ClientId;
            JObject data = new JObject();
            var asdf = request.Data;
            data.Add(location[0], request.Data.SelectToken(location[1])?.ToString() ?? "");
            document.Data = BsonDocument.Parse(data.ToString());



            return document;
        }
        public PokemonDocument Update(Models.PokemonDocument pokemon, JObject PkmData)
        {

            JsonPatchDocument patch = new JsonPatchDocument();

            var data = JObject.Parse(pokemon.Data.ToString());

            var stats = PkmData["stats"];
            Dictionary<string, string> statsDic = stats.ToDictionary(stat => stat["stat"]["name"].ToString(), stat => stat["base_stat"].ToString());

            //patch.Add("stats", (stats[0].Value(),3,5) );


            int num = 0;
            string[] statNames = new string[6];
            string[] statValues = new string[6];

            JArray statValuesArray = new JArray();  

           JObject _par = new JObject();
            foreach (var stat in statsDic)
            {
                KeyValuePair<string, string> par = new KeyValuePair<string, string>(stat.Key, stat.Value);
                _par[stat.Key] = stat.Value;
                //par.Key = stat.Key;
                //statNames[num] = stat.Key;
                //statValues[num] = stat.Value;
                //num = num+1;

                //statValuesArray.Add(_par);  
            }
            patch.Add("stats", _par);
            //patch.Add("stats/-", );

            var serialized = Newtonsoft.Json.JsonConvert.SerializeObject(patch);
            try
            {
                patch.ApplyTo(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            pokemon.Data =  BsonDocument.Parse(data.ToString());
            //patch.Add("op", "add");
            //patch.Add("path", "/info");
            //patch.Add("value", "noseque");
            //patch.ApplyTo()
            //JsonHandler _handler = new JsonHandler();
            return pokemon;

        }

    }
}
