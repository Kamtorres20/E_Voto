﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sufragantes.API.Controllers.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class BasicAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public BasicAuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            string authHeader = httpContext.Request.Headers["Authorization"];
            if (authHeader != null && authHeader.StartsWith("Basic"))
            {
                string ecodeusernameandpassword = authHeader.Substring("Basic".Length).Trim();
                Encoding encoding = Encoding.GetEncoding("UTF-8");
                string usernameandpassword = encoding.GetString(Convert.FromBase64String(ecodeusernameandpassword));
                int index = usernameandpassword.IndexOf(":");
                var username = usernameandpassword.Substring(0, index);
                var password = usernameandpassword.Substring(index + 1);
                if (username.Equals("UserEvoto_1") && password.Equals("PassEvoto_1"))
                {
                    await _next.Invoke(httpContext);
                }
                else
                {
                    httpContext.Response.StatusCode = 401;
                    return;
                }
            }
            else
            {
                httpContext.Response.StatusCode = 401;
                return;
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class BasicAuthenticationMiddlewareExtensions
    {
        public static IApplicationBuilder UseBasicAuthenticationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BasicAuthenticationMiddleware>();
        }
    }
}
