using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoMagazine.DataAccess
{
    public class DependecyManager
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddSingleton(new DataConfiguration(connectionString));
        }
    }
}
