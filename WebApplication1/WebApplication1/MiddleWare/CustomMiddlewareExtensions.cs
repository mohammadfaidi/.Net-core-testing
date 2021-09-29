using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

	
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace WebApplication1.MiddleWare
{
    //6. Handling Errors Globally with the Custom Middleware
    public class CustomMiddlewareExtensions
    {
        public RequestDelegate _next;
        public CustomMiddlewareExtensions(RequestDelegate next)
        {
            this._next = next;
        }
        public async Task InvokeAsync(HttpContext httpcontext)
        {
            try
            {
                await _next(httpcontext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpcontext, ex);
            }
        }
        private static Task HandleExceptionAsync(HttpContext httpcontext, Exception ex)
        {
            

            httpcontext.Response.ContentType = "application/json";
            httpcontext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var response = new ErrorVm()
            {
                StatusCode = httpcontext.Response.StatusCode,
                Message = "Internal Server Error from the custom middlewaree",
                Path = "Path-goes here",

            };
            return httpcontext.Response.WriteAsync(response.ToString());
            
        }
    }
}

