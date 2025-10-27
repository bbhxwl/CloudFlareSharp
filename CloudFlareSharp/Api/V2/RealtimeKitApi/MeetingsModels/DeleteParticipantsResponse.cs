using System;
using Newtonsoft.Json;

namespace CloudFlareSharp.Api.V2.RealtimeKitApi.MeetingsModels
{
    public class DeleteParticipantsResponse
    {
        [JsonProperty("custom_participant_id")]
        public string CustomParticipantId { get; set; }
        [JsonProperty("preset_id")]
        public string PresetId { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}