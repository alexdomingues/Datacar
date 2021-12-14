using Datacar.Client.Helpers;
using Datacar.Client.Repository;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Datacar.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            // to configure services through Dependency injection
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            // to configure our services
            ConfigureServices(builder.Services);

            await builder.Build().RunAsync();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // configure our services in Service.cs and dependency injection
            services.AddSingleton<SingletonService>();
            services.AddTransient<TransientService>();
            //configure the IRepository service and the class that implements the interface
            //easily change the class to implement other sources,apis, etc
            services.AddTransient<IRepository, RepositoryInMemory>();
            services.AddScoped<IHttpService, HTTPService>();
            services.AddScoped<IUsersRepository, UsersRepository>();
        }
    }
}
