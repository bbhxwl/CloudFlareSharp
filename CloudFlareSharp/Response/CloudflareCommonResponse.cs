using System.Collections.Generic;
using CloudFlareSharp.Response.Errors;
using CloudFlareSharp.Response.Messages;
using Newtonsoft.Json;

namespace CloudFlareSharp.Response
{
    public class CloudflareCommonResponse<T>
    {
        [JsonProperty("errors")] public List<CommonErrorResponse> Errors { get; set; }
        [JsonProperty("messages")] public List<CommonMessagesResponse> Messages { get; set; }
        [JsonProperty("result")] public T Result { get; set; }
        [JsonProperty("success")] public bool Success { get; set; }
    }
}