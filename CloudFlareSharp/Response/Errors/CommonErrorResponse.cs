using Newtonsoft.Json;

namespace CloudFlareSharp.Response.Errors
{
    public class CommonErrorResponse
    {
        [JsonProperty("code")]
        public int Code { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("documentation_url")]
        public string DocumentationUrl { get; set; }
    }
}