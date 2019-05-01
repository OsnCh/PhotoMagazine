using System;
using Microsoft.Extensions.DependencyInjection;
using PhotoMagazine.DataAccess.Repositories;
using PhotoMagazine.DataAccess.Repositories.Interfaces;


namespace PhotoMagazine.DataAccess
{
    public class DependecyManager
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddSingleton(new DataConfiguration(connectionString));

            services.AddSingleton<IUserConfirmationCodeRepository, UserConfirmationCodeRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IPostRepository, PostRepository>();
        }
    }
}
