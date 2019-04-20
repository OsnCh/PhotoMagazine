using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoMagazine.Api.Configuration
{
    public static class ApiInformation
    {
        public static void ApiInformationConfigure(this IServiceCollection services,IConfiguration configuration)
        {
            services.Configure<Business.Commons.ApiInformation>(options => {
                options.Name = configuration[$"{nameof(Business.Commons.ApiInformation)}:{nameof(options.Name)}"];
                options.Description = configuration[$"{nameof(Business.Commons.ApiInformation)}:{nameof(options.Description)}"];
                options.Contact = configuration[$"{nameof(Business.Commons.ApiInformation)}:{nameof(options.Contact)}"];
            });
        }
    }
}
