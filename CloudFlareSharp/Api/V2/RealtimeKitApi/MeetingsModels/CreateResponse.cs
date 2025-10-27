using System;
using Newtonsoft.Json;

namespace CloudFlareSharp.Api.V2.RealtimeKitApi.MeetingsModels
{
    public class CreateResponse
    {
        /// <summary>
        /// 本次会议应在哪个地区举行。
        /// The region in which this meeting should be created.
        /// </summary>
        [JsonProperty("preferred_region")]
        public string PreferredRegion { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        /// <summary>
        /// 指定是否应在有人加入会议后立即开始录制会议。
        /// Specifies if the meeting should start getting recorded as soon as someone joins the meeting.
        /// </summary>
        [JsonProperty("record_on_start")]
        public bool RecordOnStart { get; set; }
        /// <summary>
        /// 指定会议是否应在开始时开始直播。
        /// Specifies if the meeting should start getting livestreamed on start.
        /// </summary>
        [JsonProperty("live_stream_on_start")]
        public bool LiveStreamOnStart { get; set; }
        /// <summary>
        /// 使用成绩单自动生成会议摘要。需要启用转录，并且可以通过Webhook或摘要API检索。
        /// Automatically generate summary of meetings using transcripts. Requires Transcriptions to be enabled, and can be retrieved via Webhooks or summary API.
        /// </summary>
        [JsonProperty("summarize_on_end")]
        public bool SummarizeOnEnd { get; set; }
        /// <summary>
        /// 指定会议中的聊天是否应持续一周。
        /// Specifies if Chat within a meeting should persist for a week.
        /// </summary>
        [JsonProperty("persist_chat")]
        public bool PersistChat { get; set; }
        [JsonProperty("is_large")]
        public bool IsLarge { get; set; }
        /// <summary>
        /// ACTIVE or INACTIVE
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}