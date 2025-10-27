using Newtonsoft.Json;

namespace CloudFlareSharp.Api.V2.RealtimeKitApi.MeetingsModels
{
    public class MeetingsCommResponse<T>
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("data")]
        public T Data { get; set; }
    }
}