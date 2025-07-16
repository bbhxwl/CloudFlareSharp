using System.Collections.Generic;
using Newtonsoft.Json;

namespace CloudFlareSharp.Response.Realtime
{
    public class IceServersResponse
    {
        [JsonProperty("iceServers")]
        public List<IceServer> IceServers { get; set; }
    }
}