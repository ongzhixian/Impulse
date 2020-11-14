﻿namespace Impulse.Applications
{
    using Impulse.CloudServices.Aws.DynamoDb;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using System;

    public class DummyAwsClientApplication : IDummyApplication
    {
        private readonly ILogger logger;
        private readonly IConfiguration configuration;
        private readonly IClient dynamoDbClient;

        public DummyAwsClientApplication(ILogger<DummyAwsClientApplication> logger, IConfiguration configuration, IClient dynamoDbClient)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            this.dynamoDbClient = dynamoDbClient ?? throw new ArgumentNullException(nameof(dynamoDbClient));

            DemoLogging();
        } // public DummyAwsClientApplication(...)

        public void Run(string[] args)
        {
            //for (int i = 0; i < 10; i++)
            //{
            //    logger.LogInformation($"Dummy AWS Client Application Message {i} {this.configuration["Application:Version"]}");
            //    System.Threading.Thread.Sleep(1000);
            //}

            logger.LogInformation($"Dummy AWS Client Application {this.configuration["Application:Version"]} start");

            bool exists = dynamoDbClient.TableExists("message").Result;

            logger.LogInformation($"message table exists: {exists}");

            exists = dynamoDbClient.TableExists("dumm").Result;

            logger.LogInformation($"dumm table exists: {exists}");

            dynamoDbClient.SaveBook();

            //dynamoDbClient.CreateTableAsync("ASSA",

            //    dynamoDbClient.AttributeDefinitionList(("AA", "AA")

            bool created = dynamoDbClient.CreateTable("ProductCatalog",
                _ => _.AttributeDefinitionList(("Id", "N")),
                _ => _.KeySchemaElementList(("Id", "HASH")),
                10, 5).Result;

            logger.LogInformation($"Table ProductCatalog created {created}");

            logger.LogInformation($"Dummy AWS Client Application  {this.configuration["Application:Version"]} end");

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