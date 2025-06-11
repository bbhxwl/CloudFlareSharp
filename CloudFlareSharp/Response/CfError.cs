using System;
using System.Collections.Generic;
using CloudFlareSharp.Response.Errors;
using CloudFlareSharp.Response.Messages;

namespace CloudFlareSharp.Response
{
    public class CfError :Exception
    {
        public List<CommonErrorResponse> Errors { get; set; }
        public List<CommonMessagesResponse> Messages { get; set; }
        public string Message { get; set; }
        public CfError(string message,List<CommonErrorResponse> errors, List<CommonMessagesResponse> messages)
            : base("Cloudflare API Error")
        {
            Errors = errors;
            Message = message;
            Messages = messages;
        }
    }
}