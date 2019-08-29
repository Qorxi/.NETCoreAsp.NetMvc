using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreKnowledge.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.Extensions.DependencyInjection;

namespace CoreKnowledge.Domain.Services.Middlewares.CustomServices
{
    public class CustomeExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IExceptionProvider _logger;

        public CustomeExceptionMiddleware(RequestDelegate next, IExceptionProvider except)
        {
            _next = next;
            _logger = except;
        }

        public async Task Invoke(HttpContext context, IExceptionProvider logger)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var loggert = context.RequestServices.GetService<IExceptionProvider>();
                loggert.Write(ex);
                context.Response.Clear();
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json; charset=utf-8";

                var error = ex.InnerException != null ?
                                  new Error { Code = ex.InnerException.HResult, Message = ex.InnerException.Message }
                                : new Error { Code = ex.HResult, Message = ex.Message };
                error.ExceptionDetails = ex;

                var resjson = JsonConvert.SerializeObject(error);
                await context.Response.WriteAsync(resjson);

            }
        }

    }

    public class Error
    {
        public int Code { get; set; }

        public string Message { get; set; }

        public Exception ExceptionDetails { get; set; }
    }
}
