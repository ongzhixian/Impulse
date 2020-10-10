namespace Impulse.ConsoleApplication
{
    using Impulse.Applications;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using System;
    using System.IO;

    class Program
    {
        protected Program()
        {
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Application start.");

            IConfigurationRoot configurationSettings = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile("appsecrets.json", true, true)
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();

            ServiceCollection services = new ServiceCollection();

            Configure(services, configurationSettings);

            using (var serviceProvider = services.BuildServiceProvider())
            {
                ILogger<Program> logger = serviceProvider.GetService<ILogger<Program>>();

                logger.LogInformation("Start application.");

                serviceProvider.GetService<IApplication>().Run(args);

                logger.LogInformation("End application.");
            }

            Console.WriteLine("Application end.");
            Console.WriteLine("Press <ENTER> key to terminate application.");
            Console.ReadLine();
        }

        private static void Configure(IServiceCollection services, IConfigurationRoot configurationRoot)
        {
            // Scope (service lifetime) notes:
            // Transient    objects are always different; a new instance is provided to every controller and every service.
            // Scoped       objects are the same within a request, but different across different requests.
            // Singleton    objects are the same for every object and every request.

            // Configurables
#pragma warning disable S125 // Sections of code should not be commented out
            // PLACEHOLDER: services.Configure<ConnectionStrings>(config.GetSection("ConnectionStrings"));
#pragma warning restore S125 // Sections of code should not be commented out
            services.AddSingleton<IConfiguration>(configurationRoot);

            // Configure logging
            services.AddLogging(_ => _.AddConsole());
            //services.AddLogging(builder =>
#pragma warning disable S125 // Sections of code should not be commented out
            //{
            //    builder.AddConsole();
            //    builder.AddDebug();
            //});
#pragma warning restore S125 // Sections of code should not be commented out

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
            services.AddTransient<IApplication, DummyApplication>();


            // IMPORTANT! Register our application entry point
            services.AddTransient<Program>();

        }
    }
}
