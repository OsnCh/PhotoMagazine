using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoMagazine.Business
{
    public class DependecyManager
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            DataAccess.DependecyManager.Configure(services, connectionString);
        }
    }
}
