using System.Collections.Generic;
using Newtonsoft.Json;

namespace CloudFlareSharp.Response.Realtime
{
    public class IceServer
    {
        [JsonProperty("urls")]
        public List<string> Urls { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("credential")]
        public string Credential { get; set; }
    }
}