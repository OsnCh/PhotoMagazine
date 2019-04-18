using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhotoMagazine.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoMagazine.Api.Configuration
{
    public static class Dependency
    {
        public static void ConfigureDependency(this IServiceCollection services, IConfiguration configuration)
        {
            DependencyManager.Configure(services, configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
