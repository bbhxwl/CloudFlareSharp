using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CloudFlareSharp.Api
{
    public class Realtime
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://rtc.live.cloudflare.com/v1";
        private readonly string _appId;
        private readonly string _token;
        public Realtime(string appId,string token)
        {
            this._appId = appId;
            this._token = token;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);
        }

        public async Task<NewSessionResponse> CreateNewSessionAsync(bool? thirdParty = null, string correlationId = null)
        {
            var url = $"{BaseUrl}/apps/{_appId}/sessions/new";
            if (thirdParty.HasValue)
                url += $"?thirdparty={thirdParty.Value}";
            if (!string.IsNullOrEmpty(correlationId))
                url += $"{(thirdParty.HasValue ? "&" : "?")}correlationId={correlationId}";

            var response = await _httpClient.PostAsync(url, null);
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<NewSessionResponse>(content);
        }

        public async Task<TracksResponse> AddTracksAsync(string sessionId, TracksRequest request)
        {
            var url = $"{BaseUrl}/apps/{_appId}/sessions/{sessionId}/tracks/new";
            var json = JsonConvert.SerializeObject(request);
            Console.WriteLine(json);
            var content = new StringContent(json);
            content.Headers.ContentType= new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = await _httpClient.PostAsync(url, content);
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TracksResponse>(responseContent);
        }

        public async Task<RenegotiateResponse> RenegotiateSessionAsync(string sessionId, RenegotiateRequest request)
        {
            var url = $"{BaseUrl}/apps/{_appId}/sessions/{sessionId}/renegotiate";
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(url, content);
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<RenegotiateResponse>(responseContent);
        }

        public async Task<CloseTracksResponse> CloseTracksAsync(string sessionId, CloseTracksRequest request)
        {
            var url = $"{BaseUrl}/apps/{_appId}/sessions/{sessionId}/tracks/close";
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(url, content);
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CloseTracksResponse>(responseContent);
        }

        public async Task<UpdateTracksResponse> UpdateTracksAsync(string sessionId, UpdateTracksRequest request)
        {
            var url = $"{BaseUrl}/apps/{_appId}/sessions/{sessionId}/tracks/update";
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(url, content);
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UpdateTracksResponse>(responseContent);
        }

        public async Task<GetSessionStateResponse> GetSessionStateAsync(string sessionId)
        {
            var url = $"{BaseUrl}/apps/{_appId}/sessions/{sessionId}";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<GetSessionStateResponse>(content);
        }

        #region Models

        public class SessionDescription
        {
            [JsonProperty("sdp", NullValueHandling = NullValueHandling.Ignore)]
            public string Sdp { get; set; }

            [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
            public string Type { get; set; }
        }

        public class TrackObject
        {
            [JsonProperty("location", NullValueHandling = NullValueHandling.Ignore)]
            public string Location { get; set; }

            [JsonProperty("mid", NullValueHandling = NullValueHandling.Ignore)]
            public string Mid { get; set; }

            [JsonProperty("sessionId", NullValueHandling = NullValueHandling.Ignore)]
            public string SessionId { get; set; }

            [JsonProperty("trackName", NullValueHandling = NullValueHandling.Ignore)]
            public string TrackName { get; set; }

            [JsonProperty("bidirectionalMediaStream", NullValueHandling = NullValueHandling.Ignore)]
            public bool? BidirectionalMediaStream { get; set; }

            [JsonProperty("kind", NullValueHandling = NullValueHandling.Ignore)]
            public string Kind { get; set; }

            [JsonProperty("simulcast", NullValueHandling = NullValueHandling.Ignore)]
            public SimulcastConfig Simulcast { get; set; }
        }

        public class SimulcastConfig
        {
            [JsonProperty("preferredRid", NullValueHandling = NullValueHandling.Ignore)]
            public string PreferredRid { get; set; }

            [JsonProperty("priorityOrdering", NullValueHandling = NullValueHandling.Ignore)]
            public string PriorityOrdering { get; set; }

            [JsonProperty("ridNotAvailable", NullValueHandling = NullValueHandling.Ignore)]
            public string RidNotAvailable { get; set; }
        }
        public class TracksRequest
        {
            [JsonProperty("sessionDescription", NullValueHandling = NullValueHandling.Ignore)]
            public SessionDescription SessionDescription { get; set; }

            [JsonProperty("tracks", NullValueHandling = NullValueHandling.Ignore)]
            public TrackObject[] Tracks { get; set; }

            // [JsonProperty("autoDiscover")]
            // public bool? AutoDiscover { get; set; }
        }

        public class TracksResponse
        {
            [JsonProperty("errorCode")]
            public string ErrorCode { get; set; }

            [JsonProperty("errorDescription")]
            public string ErrorDescription { get; set; }

            [JsonProperty("requiresImmediateRenegotiation")]
            public bool RequiresImmediateRenegotiation { get; set; }

            [JsonProperty("sessionDescription")]
            public SessionDescription SessionDescription { get; set; }

            [JsonProperty("tracks")]
            public TrackObject[] Tracks { get; set; }
        }

        public class NewSessionResponse
        {
            [JsonProperty("sessionId")]
            public string SessionId { get; set; }

            [JsonProperty("errorCode")]
            public string ErrorCode { get; set; }

            [JsonProperty("errorDescription")]
            public string ErrorDescription { get; set; }

            [JsonProperty("sessionDescription")]
            public SessionDescription SessionDescription { get; set; }
        }

        public class CloseTracksRequest
        {
            [JsonProperty("sessionDescription", NullValueHandling = NullValueHandling.Ignore)]
            public SessionDescription SessionDescription { get; set; }

            [JsonProperty("tracks", NullValueHandling = NullValueHandling.Ignore)]
            public CloseTrackObject[] Tracks { get; set; }

            [JsonProperty("force", NullValueHandling = NullValueHandling.Ignore)]
            public bool? Force { get; set; }
        }

        public class CloseTrackObject
        {
            [JsonProperty("mid", NullValueHandling = NullValueHandling.Ignore)]
            public string Mid { get; set; }
        }

        public class CloseTracksResponse
        {
            [JsonProperty("errorCode")]
            public string ErrorCode { get; set; }

            [JsonProperty("errorDescription")]
            public string ErrorDescription { get; set; }

            [JsonProperty("sessionDescription")]
            public SessionDescription SessionDescription { get; set; }

            [JsonProperty("tracks")]
            public CloseTrackObject[] Tracks { get; set; }

            [JsonProperty("requiresImmediateRenegotiation")]
            public bool RequiresImmediateRenegotiation { get; set; }
        }

        public class GetSessionStateResponse
        {
            [JsonProperty("errorCode")]
            public string ErrorCode { get; set; }

            [JsonProperty("errorDescription")]
            public string ErrorDescription { get; set; }

            [JsonProperty("tracks")]
            public SessionTrackObject[] Tracks { get; set; }
        }

        public class SessionTrackObject : TrackObject
        {
            [JsonProperty("status")]
            public string Status { get; set; }
        }

        public class RenegotiateRequest
        {
            [JsonProperty("sessionDescription", NullValueHandling = NullValueHandling.Ignore)]
            public SessionDescription SessionDescription { get; set; }
        }

        public class RenegotiateResponse
        {
            [JsonProperty("errorCode", NullValueHandling = NullValueHandling.Ignore)]
            public string ErrorCode { get; set; }

            [JsonProperty("errorDescription", NullValueHandling = NullValueHandling.Ignore)]
            public string ErrorDescription { get; set; }

            [JsonProperty("sessionDescription", NullValueHandling = NullValueHandling.Ignore)]
            public SessionDescription SessionDescription { get; set; }
        }

        public class UpdateTracksRequest
        {
            [JsonProperty("tracks", NullValueHandling = NullValueHandling.Ignore)]
            public TrackObject[] Tracks { get; set; }

            [JsonProperty("sessionDescription", NullValueHandling = NullValueHandling.Ignore)]
            public SessionDescription SessionDescription { get; set; }
        }

        public class UpdateTracksResponse
        {
            [JsonProperty("errorCode")]
            public string ErrorCode { get; set; }

            [JsonProperty("errorDescription")]
            public string ErrorDescription { get; set; }

            [JsonProperty("requiresImmediateRenegotiation")]
            public bool RequiresImmediateRenegotiation { get; set; }

            [JsonProperty("tracks")]
            public TrackObject[] Tracks { get; set; }
        }

        #endregion
        
    }
}