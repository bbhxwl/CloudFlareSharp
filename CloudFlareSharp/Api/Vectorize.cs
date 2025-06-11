using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CloudFlareSharp.Helper;
using CloudFlareSharp.Response;
using CloudFlareSharp.Response.Vectorize;
using CloudFlareSharp.Response.Vectorize.Enum;
using Newtonsoft.Json;

namespace CloudFlareSharp.Api
{
    
    public class Vectorize
    {
        private HttpHelper http;
        private CloudFlare _cf;
        private const string BaseUrl = "https://api.cloudflare.com/client/v4/accounts";
        public Vectorize(CloudFlare cf)
        {
            this._cf = cf;
            http = new HttpHelper(cf.AuthEmail,cf.AuthKey);
        }
        public async Task<CloudflareCommonListResponse<GetByIdsResponse>> GetByIds(string accountId,string indexName,List<string> ids)
        {
            var res=await http.PostAsync<CloudflareCommonListResponse<GetByIdsResponse>>($"{BaseUrl}/{accountId}/vectorize/v2/indexes/{indexName}/get_by_ids",new
            {
                ids=ids
            });
            return res;
        }
        public async Task<CloudflareCommonResponse<QueryResponse>> Query(string accountId,string indexName,List<double> vector,object filter=null,VectorReturnMetadataEnum returnMetadata= VectorReturnMetadataEnum.none,bool returnValues=false,int topK=5)
        {
            var res=await http.PostAsync<CloudflareCommonResponse<QueryResponse>>($"{BaseUrl}/{accountId}/vectorize/v2/indexes/{indexName}/query",new
            {
                vector,
                filter,
                returnMetadata=returnMetadata.ToString(),
                returnValues,
                topK
            });
            return res;
        }
        
        public async Task<CloudflareCommonResponse<QueryResponse>> QueryById(string accountId,string indexName,string id,object filter=null,VectorReturnMetadataEnum returnMetadata= VectorReturnMetadataEnum.none,bool returnValues=false,int topK=5)
        {
            var rs = await GetByIds(accountId, indexName, new List<string> { id });
            if (rs.Result ==null || rs.Result.Count == 0)
            {
                throw new CfError("NotFound Id Data",rs.Errors,rs.Messages);
            }
            return await Query(accountId,indexName,rs.Result[0].Values,filter,returnMetadata,returnValues,topK);
        }
        
        public async Task<CloudflareCommonResponse<DeleteVectorByIdsResponse>> DeleteVectorByIds(string accountId,string indexName,List<string> ids)
        {
            return await http.PostAsync<CloudflareCommonResponse<DeleteVectorByIdsResponse>>($"{BaseUrl}/{accountId}/vectorize/v2/indexes/{indexName}/delete_by_ids", new
            {
                ids
            });
        }
    }
}