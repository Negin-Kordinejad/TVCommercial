using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OptimizerService.Bussines;
using OptimizerService.Helper;
using OptimizerService.InternalService;
using OptimizerService.Model;
using OptimizerService.Services;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace TVCommercial
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = InitConfig();

            var svc = ActivatorUtilities.CreateInstance<CommertialObtimizer>(host.Services);
            var printSvc = ActivatorUtilities.CreateInstance<PrintModelService>(host.Services);

            PrintModel printModel = svc.FindOptimalPlacement();
            printSvc.Print(printModel);


        }
        static IHost InitConfig()
        {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            Log.Logger.Information("Application Starting");

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<ICommertialObtimizer, CommertialObtimizer>();
                    services.AddTransient<ICommercialPlacement, CommercialPlacement>();
                    services.AddTransient<IPrintModel, PrintModelService>();
                    services.AddTransient<IOptimizeHelper, OptimizeHelper>();
                    services.AddTransient<IInitialDataHelper, InitialDataHelper>();
                })
                .UseSerilog()
                .Build();
            return host;
        }
        static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                .AddEnvironmentVariables();
        }


    }

}
