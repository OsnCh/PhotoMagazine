using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhotoMagazine.DataAccess;
using PhotoMagazine.Entitys.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoMagazine.Api.Configuration
{
    public static class DBContext
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options => {
                options.UseSqlServer(connectionString,
                b => {
                    b.MigrationsAssembly("PhotoMagazine.DataAccess");
                    b.EnableRetryOnFailure();
                });
            });
            services.AddIdentity<ApplicationUser, IdentityRole>(options => options.Password.RequireNonAlphanumeric = false).
                AddEntityFrameworkStores<ApplicationDbContext>().
                AddDefaultTokenProviders();
            
        }
    }
}
