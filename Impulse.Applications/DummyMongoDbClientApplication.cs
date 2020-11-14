namespace Impulse.Applications
{
    using Impulse.CloudServices.Aws.DynamoDb;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using System;

    public class DummyMongoDbClientApplication : IDummyApplication
    {
        private readonly ILogger logger;
        private readonly IConfiguration configuration;
        private readonly IClient dynamoDbClient;

        public DummyMongoDbClientApplication(ILogger<DummyAwsClientApplication> logger, IConfiguration configuration, IClient dynamoDbClient)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            this.dynamoDbClient = dynamoDbClient ?? throw new ArgumentNullException(nameof(dynamoDbClient));

        } // public DummyAwsClientApplication(...)

        public void Run(string[] args)
        {
            
            logger.LogInformation($"Dummy AWS Client Application {this.configuration["Application:Version"]} start");

            bool exists = dynamoDbClient.TableExists("message").Result;

            logger.LogInformation($"message table exists: {exists}");

            //dynamoDB.CreateTableAsync()

            exists = dynamoDbClient.TableExists("dumm").Result;

            logger.LogInformation($"dumm table exists: {exists}");

            dynamoDbClient.SaveBook();

            logger.LogInformation($"Dummy AWS Client Application  {this.configuration["Application:Version"]} end");

        } // Run(...)



    } // public class DummyApplication : IDummyApplication

} // namespace Impulse.Applications