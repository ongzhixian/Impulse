namespace Impulse.Applications
{
    using Impulse.Common;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading.Tasks;

    public class ApplicationDomainApplication : IApplication
    {
        private readonly ILogger logger;
        private readonly IConfiguration configuration;

        public ApplicationDomainApplication(ILogger<DummyApplication> logger, IConfiguration configuration)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            
            Console.WriteLine("Creating new AppDomain.");
            
            // ZX: This code does not work in .NET Core 
            // AppDomains are not supported in .NET Core
            AppDomain domain = AppDomain.CreateDomain("MyDomain");

            Console.WriteLine("Host domain: " + AppDomain.CurrentDomain.FriendlyName);
            Console.WriteLine("child domain: " + domain.FriendlyName);

        } // public DummyApplication(...)

        public Task Run(string[] args)
        {
            return Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    logger.LogInformation($"Dummy Application Message {i} {this.configuration["Application:Version"]}");
                    System.Threading.Thread.Sleep(1000);
                }
            });
            
        } // Run(...)


    } // public class DummyApplication : IDummyApplication
} // namespace Impulse.Applications