using System;
using Newtonsoft.Json;

namespace CloudFlareSharp.Api.V2.RealtimeKitApi.MeetingsModels
{
    public class CreateResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("data")]
        public DataModel Data { get; set; }
        
        public class DataModel
        {
            [JsonProperty("preferred_region")]
            public string PreferredRegion { get; set; }
            [JsonProperty("id")]
            public string Id { get; set; }
            [JsonProperty("title")]
            public string Title { get; set; }
            [JsonProperty("record_on_start")]
            public bool RecordOnStart { get; set; }
            [JsonProperty("live_stream_on_start")]
            public bool LiveStreamOnStart { get; set; }
            [JsonProperty("summarize_on_end")]
            public bool SummarizeOnEnd { get; set; }
            [JsonProperty("persist_chat")]
            public bool PersistChat { get; set; }
            [JsonProperty("is_large")]
            public bool IsLarge { get; set; }
            [JsonProperty("status")]
            public string Status { get; set; }
            [JsonProperty("created_at")]
            public DateTime CreatedAt { get; set; }
            [JsonProperty("updated_at")]
            public DateTime UpdatedAt { get; set; }
        }
    }
}