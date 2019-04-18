using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace PhotoMagazine.Api
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var host = BuildWebHost(args);
            
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var configuration = services.GetRequiredService<IConfiguration>();
                    await Business.Auth.Identity.Initialize(services, configuration);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    //var logger = services.GetRequiredService<ILogger<Program>>();
                    //logger.LogError(exception, "An error occurred while creating roles");
                }
            }

            await host.RunAsync();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .UseDefaultServiceProvider(options => options.ValidateScopes = false)
            .Build();
    }
}
