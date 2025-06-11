using Newtonsoft.Json;

namespace CloudFlareSharp.Response.Vectorize
{
    public class DeleteVectorByIdsResponse
    {
        [JsonProperty("mutationId")]
        public string MutationId { get; set; }
    }
}