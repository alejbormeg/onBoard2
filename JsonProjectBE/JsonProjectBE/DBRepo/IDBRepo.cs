using Newtonsoft.Json.Linq;

namespace JsonProjectBE.DBRepo
{
    public interface IDBRepo
    {
        public Task AsyncStoreJson(JObject data);
        public Task AsyncStoreJson(string data);
    }
}
