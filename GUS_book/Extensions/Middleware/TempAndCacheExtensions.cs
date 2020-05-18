using GUS_book.Middleware;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GUS_book.Extensions.Services
{
    public static class TempAndCacheExtensions
    {
        public static IApplicationBuilder UseTempHandler(this IApplicationBuilder builder, string action)
        {
            return builder.UseMiddleware<TempMiddleware>(action);
        }
    }
}
