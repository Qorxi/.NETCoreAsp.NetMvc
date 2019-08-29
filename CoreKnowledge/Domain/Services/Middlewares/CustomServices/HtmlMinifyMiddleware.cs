using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreKnowledge.Domain.Services.Middlewares.CustomServices
{
    public class HtmlMinifyMiddleware
    {
        private RequestDelegate _next;

        public HtmlMinifyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next(context);
        }
    }
}
