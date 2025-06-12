using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CloudFlareSharp.Response.Vectorize
{
    public class QueryMatchesResponse
    {
        [JsonProperty("metadata")]
        public JObject Metadata { get; set; }
        [JsonProperty("namespace")]
        public string Namespace { get; set; }
        [JsonProperty("score")]
        public double Score { get; set; }
        [JsonProperty("values")]
        public List<double>? Values { get; set; }
        
    }
}