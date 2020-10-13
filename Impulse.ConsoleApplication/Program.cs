﻿namespace Impulse.ConsoleApplication
{
    using Impulse.Applications;
    using Impulse.Common;
    using Impulse.Common.Constants;
    using Impulse.Common.Extensions;
    using Impulse.Common.Models;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using NLog.Extensions.Logging;
    using Serilog;
    using System;
    using System.IO;
    using ILogger = Microsoft.Extensions.Logging.ILogger;

    class Program
    {
        protected Program()
        {
            // Intentionally left empty to fix Sonar (S1118)
        }

        static void Main(string[] args)
        {
            ILogger logger;

            using (ILoggerFactory loggerFactory = LoggerFactory.Create(_ =>
            {
                _.SetMinimumLevel(LogLevel.Information);
                _.AddConsole();
            })) logger = loggerFactory.CreateLogger(typeof(Program));

            logger.LogInformation("{EventId} Program starting. ", ProgramEvents.PROGRAM_START);

            logger.LogInformation("Getting configuration settings.");
            IConfigurationRoot configurationSettings = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile("appsecrets.json", true, true)
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();
            logger.LogInformation("Configuration settings set.");

            ServiceCollection services = new ServiceCollection();

            Configure(services, logger, configurationSettings);

            using (var serviceProvider = services.BuildServiceProvider())
            {
                logger.LogInformation("{EventId}", ProgramEvents.APPLICATION_START);

                serviceProvider.GetService<IApplication>().Run(args);

                logger.LogInformation("{EventId}", ProgramEvents.APPLICATION_END);
            }

            logger.LogInformation("{EventId} Program end. ", ProgramEvents.PROGRAM_END);

            Console.WriteLine("Press <ENTER> key to terminate program.");
            Console.ReadLine();
        }

        private static void Configure(IServiceCollection services, ILogger logger, IConfigurationRoot configuration)
        {
            logger.LogInformation("Configuring services.");

            // Scope (service lifetime) notes:
            // Singleton (0)    Specifies that a single instance of the service will be created.
            //                  => objects are the same for every object and every request.
            // Scoped (1)       Specifies that a new instance of the service will be created for each scope.
            //                  In ASP.NET Core applications a scope is created around each server request.
            //                  => objects are the same within a request, but different across different requests.
            //Transient (2)     Specifies that a new instance of the service will be created every time it is requested.
            //                  => objects are always different; a new instance is provided to every controller and every service.

            // Configuration settings should always come first, followed by logging
            services.AddSingleton<IConfiguration>(configuration);

            // Logging
            services.AddLogging(_ => 
            {
                if (File.Exists("NLog.config")) // Use NLog only if NLog.config file is found
                    _.AddNLog(configuration);

                if (configuration.IsTrue("Application:EnableSerilog"))
                {
                    _.AddSerilog(new LoggerConfiguration()
                        .ReadFrom.Configuration(configuration)
                        .CreateLogger());
                }

                if (configuration.IsTrue("Application:EnableDefaultConsoleLogging"))
                    _.AddConsole();
            });

            DependencyInjectionConfiguration dependencyInjectionConfiguration = new DependencyInjectionConfiguration();
            configuration.GetSection("DependencyInjection").Bind(dependencyInjectionConfiguration);

            DependencyInjector dependencyInjector = new DependencyInjector(logger);
            dependencyInjector.InjectServices(services, dependencyInjectionConfiguration);

#pragma warning disable S125 // Sections of code should not be commented out
            // New way of doing this?
            //services.Configure<DependencyInjectionConfiguration>(configuration.GetSection("DependencyInjection"));



            // PLACEHOLDER: services.Configure<ConnectionStrings>(config.GetSection("ConnectionStrings"));

            // Configure logging

            //services.AddLogging(builder =>
            //{
            //    builder.AddConsole();
            //    builder.AddDebug();
            //});


            //var servicesConfiguration = configuration.Get<ServicesConfiguration>();

            //foreach (var service in servicesConfiguration.Singleton)
            //{
            //    services.AddSingleton(Type.GetType(service.Service), Type.GetType(service.Implementation));
            //}

            //foreach (var service in servicesConfiguration.Transient)
            //{
            //    services.AddTransient(Type.GetType(service.Service), Type.GetType(service.Implementation));
            //}


            // Add business injectables
            //DependencyInjector dependencyInjector = new DependencyInjector(dependencyInjectionConfiguration, );
            //DependencyInjector.InjectServices();

            //services.AddTransient<IApplication, DummyApplication>();

            //            Microsoft.Extensions.DependencyInjection.ServiceDescriptor
            //Microsoft.Extensions.DependencyInjection.ServiceLifetime

            //                    ServiceDescriptor sd = new ServiceDescriptor(
            //serviceType,
            //implementationType,
            //serviceLifetime);
            //        services.Add(sd);


#pragma warning restore S125 // Sections of code should not be commented out


            // IMPORTANT! Register our application entry point
            services.AddTransient<Program>();

            logger.LogInformation("Services set.");
        }
    }
}