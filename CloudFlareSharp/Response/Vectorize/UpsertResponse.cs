using Newtonsoft.Json;

namespace CloudFlareSharp.Response.Vectorize
{
    public class UpsertResponse
    {
        [JsonProperty("mutationId")]
        public string MutationId { get; set; }
    }
}