namespace Impulse.Applications
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading.Tasks;

    public interface IDummyApplication : IApplication
    {
    } // public interface IDummyApplication : IApplication

    public class DummyApplication : IDummyApplication
    {
        private readonly ILogger logger;
        private readonly IConfiguration configuration;

        public DummyApplication(ILogger<DummyApplication> logger, IConfiguration configuration)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

            DemoLogging();
        } // public DummyApplication(...)

        public Task RunAsync(string[] args)
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

        private void DemoLogging()
        {
            logger.LogTrace("Logging trace");
            logger.LogDebug("Logging debug information.");
            logger.LogInformation("Logging information.");
            logger.LogWarning("Logging warning.");
            logger.LogError("Logging error information.");
            logger.LogCritical("Logging critical information.");
        } // private void DemoLogging()
    } // public class DummyApplication : IDummyApplication
} // namespace Impulse.Applications