namespace Impulse.Applications
{
    using Impulse.Common;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading.Tasks;

    public class UdpClientApplication : IApplication
    {
        private readonly ILogger logger;
        private readonly IConfiguration configuration;

        public UdpClientApplication(ILogger<UdpClientApplication> logger, IConfiguration configuration)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

        } // public UdpClientApplication(...)

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

    } // public class UdpClientApplication : IApplication
} // namespace Impulse.Applications