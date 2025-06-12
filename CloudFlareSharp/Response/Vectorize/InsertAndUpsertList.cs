using System.Collections.Generic;
using Newtonsoft.Json;

namespace CloudFlareSharp.Response.Vectorize
{
    public class InsertAndUpsertList
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("values")]
        public List<double> Values { get; set; }
        [JsonProperty("metadata" , NullValueHandling = NullValueHandling.Ignore)]
        public object Metadata { get; set; }
        [JsonProperty("namespace", NullValueHandling = NullValueHandling.Ignore)]
        public string Namespace { get; set; }
    }
}