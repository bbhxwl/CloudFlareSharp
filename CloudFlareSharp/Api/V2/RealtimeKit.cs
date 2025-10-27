using System.Net.Http;
using CloudFlareSharp.Api.V2.RealtimeKitApi;

namespace CloudFlareSharp.Api.V2
{
    public class RealtimeKit
    {
        private readonly HttpClient _httpClient;
        private string _apiKey = null;
        public Meetings Meetings { get; private set; }
        public RealtimeKit(string apiKey,HttpClient httpClient=null)
        {
            this._apiKey = apiKey;
            _httpClient = httpClient ?? new HttpClient();
            Meetings = new Meetings(apiKey,_httpClient);
        }
        
        
    }
}