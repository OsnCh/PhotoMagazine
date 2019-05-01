using Microsoft.Extensions.DependencyInjection;
using PhotoMagazine.Business.Auth;
using PhotoMagazine.Business.Services;
using PhotoMagazine.Business.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoMagazine.Business
{
    public class DependencyManager
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            DataAccess.DependecyManager.Configure(services, connectionString);

            services.AddSingleton<JwtFactory, JwtFactory>();
            services.AddSingleton<IAccountService, AccountService>();
            services.AddSingleton<IPostService, PostService>();
        }
    }
}
