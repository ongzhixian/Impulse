namespace Impulse.ConsoleHost
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
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
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

            Dictionary<string, string> parsedArgs = args.ToDictionary('=');

            logger.LogInformation("Getting configuration settings.");

            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile("appsecrets.json", true, true)
                .AddEnvironmentVariables()
                .AddCommandLine(args);

            string secretsFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".impulse.secrets.json");
            if (File.Exists(secretsFilePath))
            {
                configurationBuilder.AddJsonFile(secretsFilePath);
            }
                
            if (parsedArgs.Count > 0)
            {
                logger.LogInformation("Setting command-line runtime arguments.");

                if (parsedArgs.ContainsKey("settings"))
                {
                    configurationBuilder.AddJsonFile(parsedArgs["settings"]);
                }

                if (parsedArgs.ContainsKey("secrets"))
                {
                    configurationBuilder.AddJsonFile(parsedArgs["secrets"]);
                }

                if (parsedArgs.ContainsKey("nlog"))
                {
                    NLog.LogManager.Configuration = new NLog.Config.XmlLoggingConfiguration(parsedArgs["nlog"]);
                }

                logger.LogInformation("Command-line runtime arguments set.");
            }

            IConfigurationRoot configurationSettings = configurationBuilder.Build();

            logger.LogInformation("Configuration settings set.");

            Console.WriteLine(configurationSettings["Application:Name"]);

            using (ILoggerFactory loggerFactory = LoggerFactory.Create(_ =>
            {
                _.SetMinimumLevel(LogLevel.Information);

                if (configurationSettings.IsTrue("Application:EnableDefaultConsoleLogging"))
                    _.AddConsole();

            })) logger = loggerFactory.CreateLogger(typeof(Program));


            logger.LogInformation("Other settings based on config.");

            ServiceCollection services = new ServiceCollection();

            Configure(services, logger, configurationSettings);

            using (var serviceProvider = services.BuildServiceProvider())
            {
                logger.LogInformation("{EventId}", ProgramEvents.APPLICATION_START);

                serviceProvider.GetService<IApplication>().RunAsync(args);

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

            // TODO: Improve the way we are logging this and the below after chunk
            
            var serviceList = services.OrderBy(_ => _.Lifetime).ToList();
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("services-before.txt"))
            {
                sw.AutoFlush = true;

                foreach (var item in serviceList)
                {
                    sw.WriteLine("{0} {1} {2} {3} {4}",
                        item.Lifetime,
                        item.ServiceType,
                        item.ImplementationFactory,
                        item.ImplementationType,
                        item.ImplementationInstance
                        );
                }
            }

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

            // TODO: Improve the way we are logging this
            serviceList = services.OrderBy(_ => _.Lifetime).ToList();
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("services-after.txt"))
            {
                sw.AutoFlush = true;

                foreach (var item in serviceList)
                {
                    sw.WriteLine("{0} {1} {2} {3} {4}",
                        item.Lifetime,
                        item.ServiceType,
                        item.ImplementationFactory,
                        item.ImplementationType,
                        item.ImplementationInstance
                        );
                }
            }

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
