namespace Impulse.WebApiHost
{
    //using Impulse.Common.Constants;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using System;
    using System.IO;

    public class Program
    {
        public static void Main(string[] args)
        {
            //ILogger logger;

            //using (ILoggerFactory loggerFactory = LoggerFactory.Create(_ =>
            //{
            //    _.SetMinimumLevel(LogLevel.Information);
            //    _.AddConsole();
            //})) logger = loggerFactory.CreateLogger(typeof(Program));

            //logger.LogInformation("{EventId} Program starting. ", ProgramEvents.PROGRAM_START);

            //logger.LogInformation("Getting configuration settings.");

            //IConfigurationRoot configurationSettings = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json", true, true)
            //    .AddJsonFile("appsecrets.json", true, true)
            //    .AddEnvironmentVariables()
            //    .AddCommandLine(args)
            //    .Build();

            //logger.LogInformation("Configuration settings set.");

            //using (ILoggerFactory loggerFactory = LoggerFactory.Create(_ =>
            //{
            //    _.SetMinimumLevel(LogLevel.Information);

            //    if (configurationSettings.IsTrue("Application:EnableDefaultConsoleLogging"))
            //        _.AddConsole();

            //}))
            //{
            //    logger = loggerFactory.CreateLogger(typeof(Program));
            //}

            //logger.LogInformation("Other settings based on config.");

            //ServiceCollection services = new ServiceCollection();

            //Configure(services, logger, configurationSettings);

            //using (var serviceProvider = services.BuildServiceProvider())
            //{
            //    logger.LogInformation("{EventId}", ProgramEvents.APPLICATION_START);

            //    //serviceProvider.GetService<IApplication>().Run(args);

            //    logger.LogInformation("{EventId}", ProgramEvents.APPLICATION_END);
            //}

            //logger.LogInformation("{EventId} Program end. ", ProgramEvents.PROGRAM_END);

            //Console.WriteLine("Press <ENTER> key to terminate program.");
            //Console.ReadLine();

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
