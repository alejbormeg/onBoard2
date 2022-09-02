using Newtonsoft.Json.Linq;

namespace JsonProjectBE.Models
{
    public class Request
    {
        public string CliendId { get; set; }
        public JObject Data { get; set; }
    }
}


// customer => JSON 
// { userdid: "·fasdfa", data: JSON }