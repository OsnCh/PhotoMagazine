using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoMagazine.Api.Configuration
{
    public static class HttpContextAccessor
    {
        public static void ConfigureHttpContextAccessor(this IServiceCollection services)
        {
            services.TryAddSingleton<IHttpContextAccessor, Microsoft.AspNetCore.Http.HttpContextAccessor>();
        }
    }
}
