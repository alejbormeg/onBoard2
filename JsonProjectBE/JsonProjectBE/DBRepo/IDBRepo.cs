using JsonProjectBE.Models;
using Newtonsoft.Json.Linq;

namespace JsonProjectBE.DBRepo
{
    public interface IDBRepo
    {
        public Task AsyncStoreJson(JObject data);
        public Task AsyncStoreDocument(Document document);
        public async Task<String> AsyncGetRequiredField(string user);
    }
}
