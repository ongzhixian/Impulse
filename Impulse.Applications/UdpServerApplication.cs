namespace Impulse.Applications
{
    using Impulse.Common;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading.Tasks;

    public class UdpServerApplication : IApplication
    {
        private readonly ILogger logger;
        private readonly IConfiguration configuration;

        public UdpServerApplication(ILogger<UdpServerApplication> logger, IConfiguration configuration)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

        } // public UdpServerApplication (...)

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

    } // public class UdpServerApplication : IApplication
} // namespace Impulse.Applications