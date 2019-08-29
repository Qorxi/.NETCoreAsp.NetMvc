using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreKnowledge.Domain.Services.Middlewares.CustomServices;
using Microsoft.AspNetCore.Builder;

namespace CoreKnowledge.Domain.Services.Middlewares.Extensions
{
    public static class HtmlMinifyMiddleExtensions
    {
        public static IApplicationBuilder HtmlMinifyExtensions(this IApplicationBuilder build)
        {
            return build.UseMiddleware<HtmlMinifyMiddleware>();
        }
    }
}
