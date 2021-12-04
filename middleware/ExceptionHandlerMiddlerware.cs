using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Chequo.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        public RequestDelegate requestDelegate;
        public ExceptionHandlingMiddleware(RequestDelegate requestDelegate)
        {
            this.requestDelegate = requestDelegate;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await requestDelegate(context);
            }
            catch (BadHttpRequestException ex)
            {
                await HandleHTTPException(context, ex);
            }
        }
        private static Task HandleHTTPException(HttpContext context, BadHttpRequestException ex)
        {
            var errorMessage = new { Message = ex.Message, Code = ex.StatusCode };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = ex.StatusCode;

            return context.Response.WriteAsJsonAsync(errorMessage);
        }
    }
}