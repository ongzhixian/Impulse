namespace Impulse.Applications
{
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


        public Task Run(string[] args)
        {
            return Task.Run(() =>
            {
                logger.LogInformation("Application start");

                //sqliteClient.CreateDatabase();

                //sqliteClient.CreateTable();

                //sqliteClient.DropTable();

                //sqliteClient.SeedData();

                // sqliteClient.GetData();

                logger.LogInformation("Application end");
            });

        } // Run(...)

    } // public class DummyMachineLearningApplication : IDummyApplication

} // namespace Impulse.Applications