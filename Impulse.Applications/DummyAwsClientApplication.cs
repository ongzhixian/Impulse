namespace Impulse.Applications
{
    using Impulse.CloudServices.Aws.DynamoDb;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

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

            //DemoLogging();
        } // public DummyAwsClientApplication(...)

        public async Task RunAsync(string[] args)
        {
            logger.LogInformation("{process} {operationState}", this, OperationState.Start);

            //dynamoDbClient.TableExists("message");

            //dynamoDbClient.TableExists("dumm");

            //dynamoDbClient.SaveBook();

            //DeleteTable("ProductCatalog");
            //DeleteTable("Forum");
            //DeleteTable("Thread");
            //DeleteTable("Reply");

            bool tableExists = await dynamoDbClient.TableExists("ProductCatalog");

            //if (tableExists)
            //{
            //    await dynamoDbClient.DeleteTable("ProductCatalog");
            //}

            await dynamoDbClient.CreateTable("ProductCatalog",
                _ => _.AttributeDefinitionList(("Id", "N")),
                _ => _.KeySchemaElementList(("Id", "HASH")),
                10, 5);

            //dynamoDbClient.SaveBook();

            await dynamoDbClient.CreateItem("ProductCatalog",
                _ => _.AttributeValueDictionary(
                    ("Id", "N", "1000"),
                    ("Title", "S", "Book 201 Title"),
                    ("ISBN", "S", "11-11-11-11"),
                    ("Authors", "SS", new List<string> { "Author1", "Author2" }),
                    ("Price", "N", "20.00"),
                    ("Dimension", "S", "8.5x11.0x.75"),
                    ("InPublication", "BOOL", false)
                    )
                );

            //
            //LoadSampleProducts();
            //LoadSampleForums();
            //LoadSampleThreads();
            //LoadSampleReplies();


            //logger.LogInformation($"Dummy AWS Client Application  {this.configuration["Application:Version"]} end");


            logger.LogInformation("{process} {operationState}", this, OperationState.End);

        } // Run(...)

        private void CreateTables()
        {
            // CreateTableProductCatalog();
            dynamoDbClient.TableExists("ProductCatalog").ContinueWith(checkTask => {
                if (!checkTask.Result)
                    dynamoDbClient.CreateTable("ProductCatalog",
                        _ => _.AttributeDefinitionList(("Id", "N")),
                        _ => _.KeySchemaElementList(("Id", "HASH")),
                        10, 5);
            });

            // CreateTableForum();
            dynamoDbClient.TableExists("Forum").ContinueWith(checkTask => {
                if (!checkTask.Result)
                    dynamoDbClient.CreateTable("Forum",
                        _ => _.AttributeDefinitionList(("Name", "S")),
                        _ => _.KeySchemaElementList(("Name", "HASH")),
                        10, 5);
            });

            // CreateTableThread()
            dynamoDbClient.TableExists("Thread").ContinueWith(checkTask => {
                if (!checkTask.Result)
                    dynamoDbClient.CreateTable("Thread",
                        _ => _.AttributeDefinitionList(("ForumName", "S"), ("Subject", "S")),
                        _ => _.KeySchemaElementList(("ForumName", "HASH"), ("Subject", "RANGE")),
                        10, 5);
            });

            // CreateTableReply();
            //dynamoDbClient.TableExists("Reply").ContinueWith(checkTask => {
            //    if (!checkTask.Result)
            //        dynamoDbClient.CreateTable("Reply",
            //            _ => _.AttributeDefinitionList(("Id", "S"), ("ReplyDateTime", "S"), ("PostedBy", "S")),
            //            _ => _.KeySchemaElementList(("Id", "HASH"), ("ReplyDateTime", "RANGE")),
            //            10, 5);
            //});

            //dynamoDbClient.CreateTable("Reply",
            //    _ => _.AttributeDefinitionList(("Id", "S"), ("ReplyDateTime", "S"), ("PostedBy", "S")),
            //    _ => _.KeySchemaElementList(("Id", "HASH"), ("ReplyDateTime", "RANGE")),
            //    10, 5);

        }

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