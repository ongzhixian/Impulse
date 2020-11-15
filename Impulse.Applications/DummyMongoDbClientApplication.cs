namespace Impulse.Applications
{
    using Impulse.DataStores.MongoDb;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading.Tasks;

    public class DummyMongoDbClientApplication : IDummyApplication
    {
        private readonly ILogger logger;
        private readonly IConfiguration configuration;
        private readonly IMongoDbClient mongoDbClient;

        public DummyMongoDbClientApplication(ILogger<DummyAwsClientApplication> logger, IConfiguration configuration, IMongoDbClient mongoDbClient)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            this.mongoDbClient = mongoDbClient ?? throw new ArgumentNullException(nameof(mongoDbClient));

            // TODO: To improve! Checking if connectionstring exists; can connect, ..etc...
            string connectionString = configuration["DataStores:MongoDb:Cluster0"];
            this.mongoDbClient.Init(connectionString);
        }

        public Task RunAsync(string[] args)
        {
            return Task.Run(() =>
            {
                //this.mongoDbClient.SetDatabase("emptool");
                this.mongoDbClient.AddDocument("emptool", "student");
            });

        } // Run(...)

    } // public class DummyMongoDbClientApplication : IDummyApplication

} // namespace Impulse.Applications