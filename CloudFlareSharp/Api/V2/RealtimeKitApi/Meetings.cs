using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CloudFlareSharp.Api.V2.RealtimeKitApi.MeetingsModels;
using Newtonsoft.Json;

namespace CloudFlareSharp.Api.V2.RealtimeKitApi
{
    public class Meetings
    {
        private readonly HttpClient _httpClient;
        private string _apiKey = null;
        private const string BaseUrl = "https://api.realtime.cloudflare.com/v2/meetings";
        public Meetings(string apiKey,HttpClient httpClient=null)
        {
            this._apiKey = apiKey;
            _httpClient = httpClient ?? new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", _apiKey);

        }

        public async Task<CreateResponse> Create(CreateRequest request)
        {
            string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
            });
            StringContent sc = new StringContent(json);
            sc.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var rs=await (await _httpClient.PostAsync($"{BaseUrl}", sc)).Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CreateResponse>(rs);
        }

        public async Task<AddParticipantsResponse> AddParticipants(string meetingId,AddParticipantsRequest request)
        {
            string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
            });
            StringContent sc = new StringContent(json);
            sc.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var rs=await (await _httpClient.PostAsync($"{BaseUrl}/{meetingId}/participants", sc)).Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AddParticipantsResponse>(rs);
        }
    }
}