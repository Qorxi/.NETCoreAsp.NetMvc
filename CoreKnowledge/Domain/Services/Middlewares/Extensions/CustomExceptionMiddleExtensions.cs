using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreKnowledge.Domain.Services.Middlewares.CustomServices;

namespace CoreKnowledge.Domain.Services.Middlewares.Extensions
{
    public static class CustomExceptionMiddleExtensions
    {
        public static IApplicationBuilder UseCustomException(this IApplicationBuilder build)
        {
            if (build ==  null)
            {
                throw new ArgumentException(nameof(build));
            }
            return build.UseMiddleware<CustomeExceptionMiddleware>();
        }
    }
}
