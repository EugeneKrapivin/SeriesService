using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SeriesSerivce.SeriesEvaluators.Fibonacci;
using SeriesSerivce.SeriesEvaluators.Prime;
using SeriesService.Interfaces;
using SeriesService.SeriesLogic;

namespace SeriesService.SeriesApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddLogging();

            services.Add(new ServiceDescriptor(typeof(ISeriesLogic), typeof(SeriesLogic.SeriesLogic), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(ISeriesCache), typeof(InMemoryCache), ServiceLifetime.Singleton));
            services.Add(new ServiceDescriptor(typeof(ISeriesEvaluator), typeof(FibonacciSeriesEvaluator), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(ISeriesEvaluator), typeof(PrimeSeriesEvaluator), ServiceLifetime.Transient));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseIISPlatformHandler();

            app.UseStaticFiles();

            app.UseMvc();
        }

        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}

