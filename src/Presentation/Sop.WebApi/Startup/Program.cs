﻿using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace Sop.WebApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Debug()
                        .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                        .Enrich.FromLogContext()
                        .WriteTo.Console()
                        .CreateLogger();


            var host = Host.CreateDefaultBuilder(args)
                           .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                           .ConfigureWebHostDefaults(webHostBuilder => webHostBuilder.UseStartup<Startup>())
                           .UseSerilog()
                           .Build();

            await host.RunAsync();
        }
    }
}