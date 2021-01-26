namespace Impulse.Applications
{
    using Impulse.Common;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading.Tasks;

    public class MulticastClientApplication : IApplication
    {
        private readonly ILogger logger;
        private readonly IConfiguration configuration;

        public MulticastClientApplication(ILogger<MulticastClientApplication> logger, IConfiguration configuration)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

        } // public MulticastClientApplication (...)

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

    } // public class MulticastClientApplication : IApplication
} // namespace Impulse.Applications