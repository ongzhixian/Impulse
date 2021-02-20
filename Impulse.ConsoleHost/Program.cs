namespace Impulse.ConsoleHost
{
    using Impulse.Common;
    using Impulse.Common.Constants;
    using Impulse.Common.Extensions;
    using Impulse.Common.Models;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
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

        static ILogger GetProgramLogger()
        {
            using (ILoggerFactory loggerFactory = LoggerFactory.Create(_ =>
            {
                _.SetMinimumLevel(LogLevel.Information);
                _.AddConsole();
            })) return loggerFactory.CreateLogger(typeof(Program));
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

                if (parsedArgs.ContainsKey("log4net"))
                {
                    //NLog.LogManager.Configuration = new NLog.Config.XmlLoggingConfiguration(parsedArgs["log4net"]);
                    configurationBuilder.AddLog4NetProvider(parsedArgs["log4net"]);
                }

                logger.LogInformation("Command-line runtime arguments set.");
            }

            IConfigurationRoot configurationSettings = configurationBuilder.Build();

            logger.LogInformation("Configuration settings set.");

            // Section for demoing various ways of reading values from App.Config

            // Method 1: appSettings
            string defaultRunTimeEnvironment = System.Configuration.ConfigurationManager.AppSettings["RuntimeEnvironment"];
            Console.WriteLine($"appSettings runTimeEnvironment is {defaultRunTimeEnvironment}");

            // Method 2: root section
            var settings = System.Configuration.ConfigurationManager.GetSection("settings") as System.Collections.Specialized.NameValueCollection;
            if (settings.Count > 0)
            {
                string runTimeEnvironment = settings["RuntimeEnvironment"];
                Console.WriteLine($"settings runTimeEnvironment is {runTimeEnvironment}");
                
                // To list all settings
                //foreach (var key in settings.AllKeys)
                //{
                //    Console.WriteLine(key + " = " + settings[key]);
                //}
            }

            // Method 3: root custom AppSettingsSection
            var demoSettings = System.Configuration.ConfigurationManager.GetSection("demo") as System.Collections.Specialized.NameValueCollection;
            if (demoSettings.Count > 0)
            {
                string runTimeEnvironment = demoSettings["RuntimeEnvironment"];
                Console.WriteLine($"demo runTimeEnvironment is {runTimeEnvironment}");
            }

            // Method 3b: root custom DictionarySectionHandler
            var bootupSettings = System.Configuration.ConfigurationManager.GetSection("bootup") as System.Collections.Hashtable;
            foreach (System.Collections.DictionaryEntry item in bootupSettings)
            {
                Console.WriteLine($"bootup {item.Key} is {item.Value}");
            }
            if (bootupSettings.Count > 0)
            {
                string runTimeEnvironment = bootupSettings["RuntimeEnvironment"] as string;
                Console.WriteLine($"bootup runTimeEnvironment (2) is {runTimeEnvironment}");
            }

            // Method 3c: root custom SingleTagSectionHandler
            var locations = System.Configuration.ConfigurationManager.GetSection("locations") as System.Collections.Hashtable;
            var importDirectory = locations["ImportDirectory"].ToString();
            var processedDirectory = locations["ProcessedDirectory"].ToString();
            var rejectedDirectory = locations["RejectedDirectory"].ToString();
            Console.WriteLine($"locations importDirectory is {importDirectory}");
            Console.WriteLine($"locations processedDirectory is {processedDirectory}");
            Console.WriteLine($"locations rejectedDirectory is {rejectedDirectory}");

            // Method 4: sectionGroup section
            var uatSettings = System.Configuration.ConfigurationManager.GetSection("UAT/settings") as System.Collections.Specialized.NameValueCollection;
            if (uatSettings.Count > 0)
            {
                string runTimeEnvironment = uatSettings["RuntimeEnvironment"];
                Console.WriteLine($"UAT/settings runTimeEnvironment is {runTimeEnvironment}");
            }

            // Method 5: sectionGroup custom AppSettingsSection
            var uatDemo = System.Configuration.ConfigurationManager.GetSection("UAT/demo") as System.Collections.Specialized.NameValueCollection;
            if (uatDemo.Count > 0)
            {
                string runTimeEnvironment = uatDemo["RuntimeEnvironment"];
                Console.WriteLine($"UAT/demo runTimeEnvironment is {runTimeEnvironment}");
            }



            //System.Configuration.KeyValueInternalCollection a;


            //var uatSettings = System.Configuration.ConfigurationManager.GetSection("UAT/settings") as System.Collections.Specialized.NameValueCollection;

            // Method 4: Custom ConfigurationSection  
            // KIV

            Console.WriteLine(configurationSettings["Application:Name"]);

            using (ILoggerFactory loggerFactory = LoggerFactory.Create(_ =>
            {
                _.SetMinimumLevel(LogLevel.Information);

                if (configurationSettings.IsTrue("Application:EnableDefaultConsoleLogging"))
                    _.AddConsole();

            })) logger = loggerFactory.CreateLogger(typeof(Program));


            logger.LogInformation("Other settings based on config.");

            // Original way to run console
            //ServiceCollection services = new ServiceCollection();

            //Configure(services, logger, configurationSettings);

            //using (var serviceProvider = services.BuildServiceProvider())
            //{
            //    logger.LogInformation("{EventId}", ApplicationEvents.APPLICATION_START);

            //    serviceProvider.GetService<IApplication>().Run(args);

            //    logger.LogInformation("{EventId}", ApplicationEvents.APPLICATION_END);
            //}

            var builder = new HostBuilder();

            builder.ConfigureServices((hostContext, services) =>
            {
                Configure(services, logger, configurationSettings);
            });

            IHost host = builder.Build();

            bool isService = !(Environment.UserInteractive || System.Diagnostics.Debugger.IsAttached);

            if (isService)
            {
                host.Services.GetServices(typeof(System.ServiceProcess.ServiceBase));
                var hostService = new ServiceBaseHost(host.Services.GetRequiredService<ILogger<ServiceBaseHost>>(), host);
                System.ServiceProcess.ServiceBase.Run(hostService);

                //var servicesToHost = host.Services.GetServices<System.ServiceProcess.ServiceBase>().ToArray();
                //System.ServiceProcess.ServiceBase.Run(servicesToHost);
            }
            else
            {
                // Run as console app
                host.Services.GetService<IApplication>().Run(args);

                //serviceProvider.GetService<IApplication>().Run(args);
                //host.Run();
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

                if (configuration.IsTrue("Application:EnableLog4Net"))
                {
                    _.AddLog4NetLogger(configuration["Log4NetConfig"]);

                    //_.AddProvider(new Logging.Loggers.Log4NetProvider())
                    //    .AddLog4NetLogger(configuration["Log4NetConfig"]);

                    //_.AddProvider(new Logging.Loggers.Log4NetProvider(
                    //    new Logging.Loggers.Log4NetConfiguration(configuration["Log4NetConfig"])
                    //    ))
                    //    .AddLog4NetLogger();


                    //.AddLog4NetLogger(log4netConfig =>
                    //{
                    //    log4netConfig.LogLevel = LogLevel.Warning;
                    //    log4netConfig.Color = ConsoleColor.DarkMagenta;
                    //});

                    //_.AddProvider(new Logging.Loggers.ColorConsoleLoggerProvider(
                    //    new Logging.Loggers.ColorConsoleLoggerConfiguration
                    //    {
                    //        LogLevel = LogLevel.Error,
                    //        Color = ConsoleColor.Red
                    //    }))
                    //    .AddColorConsoleLogger()
                    //    .AddColorConsoleLogger(log4netConfig =>
                    //    {
                    //        log4netConfig.LogLevel = LogLevel.Warning;
                    //        log4netConfig.Color = ConsoleColor.DarkMagenta;
                    //    });
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

        #region Obsolete functions
        [Obsolete("No longer in used.", true)]
        public static async Task xxxMain(string[] args)
        {
            ILogger logger = GetProgramLogger();

            logger.LogInformation("{EventId} Program starting. ", ProgramEvents.PROGRAM_START);

            HostBuilder hostBuilder = new HostBuilder();

            logger.LogInformation("Getting configuration settings.");

            hostBuilder.ConfigureHostConfiguration(_ =>
            {
                _.SetBasePath(Directory.GetCurrentDirectory());
                _.AddJsonFile("appsettings.json", true, true);
                _.AddJsonFile("appsecrets.json", true, true);
                _.AddEnvironmentVariables();
                _.AddCommandLine(args);
            });

            // ZX: Some to take note of
            //hostBuilder.ConfigureAppConfiguration()

            await hostBuilder.RunConsoleAsync();

            logger.LogInformation("{EventId} Program end. ", ProgramEvents.PROGRAM_END);

            Console.WriteLine("Press <ENTER> key to terminate program.");
            Console.ReadLine();
        }

        #endregion
    }
}
