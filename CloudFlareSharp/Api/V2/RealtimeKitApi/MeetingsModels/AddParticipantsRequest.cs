using Newtonsoft.Json;

namespace CloudFlareSharp.Api.V2.RealtimeKitApi.MeetingsModels
{
    public class AddParticipantsRequest
    {
        public AddParticipantsRequest(string customParticipantId,string presetName="group_call_host")
        {
            this.CustomParticipantId = customParticipantId;
            this.PresetName= presetName;
        }
        /// <summary>
        /// (可选) 参与者名称。
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// (可选) 用于参与者的头像图片URL。
        /// </summary>
        [JsonProperty("picture")]
        public string Picture { get; set; }
        /// <summary>
        /// 应用于此参与者的预设名称。
        /// </summary>
        [JsonProperty("preset_name")]
        public string PresetName { get; set; } = "group_call_host";
        /// <summary>
        /// 唯一的参与者ID。您必须为参与者指定一个唯一ID，例如UUID、电子邮件地址等。
        /// </summary>
        [JsonProperty("custom_participant_id")]
        public string CustomParticipantId { get; set; }
    }
}