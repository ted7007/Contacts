using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Formatting.Compact;
using Serilog.Sinks.Grafana.Loki;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                                .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
                                .Enrich.FromLogContext()
                                .WriteTo.Console()
                                .CreateLogger();
            //try/catch block will ensure any configuration issues are appropriately logged
            try
            {
                Log.Information("Staring the Host");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host Terminated Unexpectedly");
            }

            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(configure =>
                {
                    configure.ClearProviders();
                })
                .UseSerilog((ctx, cfg) =>
                {
                    //Override Few of the Configurations
                    cfg.Enrich.WithProperty("Application", ctx.HostingEnvironment.ApplicationName)
                       .Enrich.WithProperty("Environment", ctx.HostingEnvironment.EnvironmentName)
                       .WriteTo.Console(new RenderedCompactJsonFormatter());
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
       
    }
}
