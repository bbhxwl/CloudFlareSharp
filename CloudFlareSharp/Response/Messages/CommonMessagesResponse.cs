using Newtonsoft.Json;

namespace CloudFlareSharp.Response.Messages
{
    public class CommonMessagesResponse
    {
        [JsonProperty("code")]
        public int Code { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("documentation_url")]
        public string DocumentationUrl { get; set; }
    }
}