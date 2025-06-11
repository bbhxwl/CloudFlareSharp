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
        public string AuthEmail = "";
        public string AuthKey = "";
        public CloudFlare(string apiToken)
        {
        }
        public CloudFlare(string authEmail,string authKey)
        {
            this.AuthEmail = authEmail;
            this.AuthKey = authKey;
            Vectorize=new Vectorize(this);
        }
        
        /// <summary>
        /// 获取SFU API
        /// </summary>
        public SFU SFU => _sfu ??= new SFU();
        public Vectorize Vectorize;
    }
}