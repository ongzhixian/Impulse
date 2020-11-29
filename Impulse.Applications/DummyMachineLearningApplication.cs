namespace Impulse.Applications
{
    using Impulse.Common;
    using Impulse.MachineLearning;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading.Tasks;

    public class DummyMachineLearningApplication : IDummyApplication
    {
        private readonly ILogger logger;
        private readonly IConfiguration configuration;
        //private readonly ISqliteClient sqliteClient;

        public DummyMachineLearningApplication(ILogger<DummyMachineLearningApplication> logger, IConfiguration configuration)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

            // TODO: To improve! Checking if connectionstring exists; can connect, ..etc...
            //string connectionString = configuration["DataStores:Sqlite:DummyApplication"];
            //this.sqliteClient.Init(connectionString);
        }


        public async Task RunAsync(string[] args)
        {
            logger.LogInformation("Application start");

            IApplication app = new InferNetExample();

            await app.RunAsync(args);

            logger.LogInformation("Application end");

        } // Run(...)

    } // public class DummyMachineLearningApplication : IDummyApplication

} // namespace Impulse.Applications