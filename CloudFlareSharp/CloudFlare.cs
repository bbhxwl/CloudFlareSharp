using System;
using System.Net.Http;
using CloudFlareSharp.Api;

namespace CloudFlareSharp
{
    /// <summary>
    /// Cloudflare API客户端
    /// </summary>
    public class CloudFlare
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiToken;
        private SFU _sfu;
        
        public CloudFlare(string apiToken)
        {
        }
        public CloudFlare(string authEmail,string authKey)
        {
        }
        

        /// <summary>
        /// 获取SFU API
        /// </summary>
        public SFU SFU => _sfu ??= new SFU();
    }
}