using System.Collections.Generic;
using Newtonsoft.Json;

namespace CloudFlareSharp.Response.Vectorize
{
    public class QueryResponse
    {
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("matches")]
        public List<QueryMatchesResponse> Matches { get; set; }
    }
}