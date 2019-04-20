using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PhotoMagazine.Api.Configuration;
using PhotoMagazine.Api.Filters;

namespace PhotoMagazine.Api
{
    public class Startup
    {
        private readonly IHostingEnvironment _env;
        private readonly IServiceScopeFactory _serviceScopeFactory;


        public Startup(IHostingEnvironment env, IServiceScopeFactory serivceScopeFactory)
        {
            _env = env;
            _serviceScopeFactory = serivceScopeFactory;
            var builder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureDbContext(Configuration);
            services.ConfigureDependency(Configuration);
            services.ConfigureAuthentication(Configuration);
            services.ApiInformationConfigure(Configuration);
            services.ConfigureHttpContextAccessor();
            services.AddMvc(options => {
                options.Filters.Add<ModelStateValidatorFilter>();
                options.Filters.Add<ResponseDataFilter>();
                options.Filters.Add(new AuthorizeFilter(new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build()));
            });

            services.BuildServiceProvider();
        }

        public IConfiguration Configuration { get; private set; }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
