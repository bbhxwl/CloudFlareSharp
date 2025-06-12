using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CloudFlareSharp.Helper
{
    public class HttpHelper
    {
        private string urlBase = "https://api.cloudflare.com/";
        private System.Net.Http.HttpClient _httpClient;

        public HttpHelper(string authEmail, string authKey)
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("X-Auth-Email", authEmail);
            _httpClient.DefaultRequestHeaders.Add("X-Auth-Key", authKey);
        }

        public async Task<T> PostAsync<T>(string path, object data)
        {
            var q = JsonConvert.SerializeObject(data);
            StringContent sc = new StringContent(q, System.Text.Encoding.UTF8, "application/json");
            string tempUrl = "";
            if (path.StartsWith("https://"))
            {
                tempUrl = path;
            }
            else
            {
                tempUrl = urlBase;
            }
            var str = await (await _httpClient.PostAsync(tempUrl, sc)).Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(str);
        }
        public async Task<T> PostNdJsonAsync<T>(string path, string ndjson)
        {
            StringContent sc = new StringContent(ndjson, System.Text.Encoding.UTF8, "application/x-ndjson");
            string tempUrl = "";
            if (path.StartsWith("https://"))
            {
                tempUrl = path;
            }
            else
            {
                tempUrl = urlBase;
            }
            var str = await (await _httpClient.PostAsync(tempUrl, sc)).Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(str);
        }

       
        private string ConvertToQueryString(object parameters)
        {
            if (parameters == null) return string.Empty;
            var jObject = JObject.FromObject(parameters);
            var queryParams = string.Join("&", jObject.Properties()
                .Select(p => $"{p.Name}={Uri.EscapeDataString(p.Value.ToString())}"));
            return queryParams.Length > 0 ? "?" + queryParams : string.Empty;
        }

        public async Task<T> GetAsync<T>(string path, object parameters = null)
        {
            var queryString = ConvertToQueryString(parameters);
            var str = await (await _httpClient.GetAsync(urlBase + path + queryString)).Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(str);
        }

        public async Task<T> DeleteAsync<T>(string path, object parameters = null)
        {
            var queryString = ConvertToQueryString(parameters);
            var str = await (await _httpClient.DeleteAsync(urlBase + path + queryString)).Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(str);
        }

        public async Task<T> PutAsync<T>(string path, object data)
        {
            StringContent sc = new StringContent(JsonConvert.SerializeObject(data));
            var str = await (await _httpClient.PutAsync(urlBase + path, sc)).Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(str);
        }
    }
}