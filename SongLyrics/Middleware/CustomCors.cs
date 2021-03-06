﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace SongLyrics.Middleware
{
    public class CustomCors
    {
        private readonly RequestDelegate FRequestDelegate;

        public CustomCors(RequestDelegate ARequestDelegate)
            => FRequestDelegate = ARequestDelegate;

        public Task Invoke(HttpContext AHttpContext, IConfiguration AConfiguration)
        {
            var LDevelopmentOrigin = AConfiguration.GetSection("DevelopmentOrigin").Value;
            var LDeploymentOrigin = AConfiguration.GetSection("DeploymentOrigin").Value;
            var LRequestOrigin = AHttpContext.Request.Headers["Origin"];

            if (LRequestOrigin != LDevelopmentOrigin && LRequestOrigin != LDeploymentOrigin)
                return FRequestDelegate(AHttpContext);
            
            AHttpContext.Response.Headers.Add("Access-Control-Allow-Origin", LRequestOrigin);
            AHttpContext.Response.Headers.Add("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
            AHttpContext.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, PATCH, DELETE");
            AHttpContext.Response.Headers.Add("Access-Control-Allow-Credentials", "true");
            AHttpContext.Response.Headers.Add("Access-Control-Max-Age", "86400");

            // Require for pre-flight
            if (AHttpContext.Request.Method != "OPTIONS") 
                return FRequestDelegate(AHttpContext);
                
            AHttpContext.Response.StatusCode = 200;
            return AHttpContext.Response.WriteAsync("OK");
        }
    }
}
