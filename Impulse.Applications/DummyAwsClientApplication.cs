namespace Impulse.Applications
{
    using Amazon.DynamoDBv2.DocumentModel;
    using Impulse.CloudServices.Aws.DynamoDb;
    using Impulse.CloudServices.Aws.Models;
    using Impulse.CloudServices.Aws.Ses;
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
        private readonly ISesClient sesClient;

        public DummyAwsClientApplication(ILogger<DummyAwsClientApplication> logger, IConfiguration configuration, IClient dynamoDbClient, ISesClient sesClient)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            this.dynamoDbClient = dynamoDbClient ?? throw new ArgumentNullException(nameof(dynamoDbClient));
            this.sesClient = sesClient ?? throw new ArgumentNullException(nameof(sesClient));

            //DemoLogging();
        } // public DummyAwsClientApplication(...)

        public async Task RunAsync(string[] args)
        {
            logger.LogInformation("{process} {operationState}", this, OperationState.Start);

            // await DynamoDbDemoAsync();

            sesClient.Send();

            logger.LogInformation("{process} {operationState}", this, OperationState.End);

        } // Run(...)

        private async Task DynamoDbDemoAsync()
        {

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

            //await dynamoDbClient.CreateTable("ProductCatalog",
            //    _ => _.AttributeDefinitionList(("Id", "N")),
            //    _ => _.KeySchemaElementList(("Id", "HASH")),
            //    10, 5);

            //await AddBooksAsync();

            //await AddBooksUsingObjectPersistenceInterfaceAsync();

            //
            //LoadSampleProducts();
            //LoadSampleForums();
            //LoadSampleThreads();
            //LoadSampleReplies();

            //dynamoDbClient.GetItem("ProductCatalog",
            //    _ => _.AttributeValueDictionary(
            //        DataType.Number.AttributeValue("Id", "2001")
            //        ),
            //    "Id, ISBN, Title, Authors"
            //    );

            Document doc = await dynamoDbClient.GetDocumentAsync("ProductCatalog", "2001");
        }

        private async Task AddBooksUsingObjectPersistenceInterfaceAsync()
        {
            await dynamoDbClient.Save(new Book
            {
                Id = 2001,
                Title = "object persistence-AWS SDK for.NET SDK-Book 1001",
                ISBN = "123-1111111001",
                BookAuthors = new List<string> { "Author 1", "Author 2" }
            });
        }

        private void AddBicycles()
        {
            //bicycle1["Id"] = 201;
            //bicycle1["Title"] = "18-Bike 201"; // size, followed by some title.
            //bicycle1["Description"] = "201 description";
            //bicycle1["BicycleType"] = "Road";
            //bicycle1["Brand"] = "Brand-Company A"; // Trek, Specialized.
            //bicycle1["Price"] = 100;
            //bicycle1["Color"] = new List<string> { "Red", "Black" };
            //bicycle1["ProductCategory"] = "Bike";

            //await dynamoDbClient.CreateItem("ProductCatalog",
            //    _ => _.AttributeValueDictionary(
            //        DataType.Number.AttributeValue("Id", "101"),
            //        DataType.String.AttributeValue("Title", "Book 101 Title"),
            //        DataType.String.AttributeValue("ISBN", "111-1111111111"),
            //        DataType.StringSet.AttributeValue("Authors", new List<string> { "Author 1" }),
            //        DataType.Number.AttributeValue("Price", "-2"),
            //        DataType.String.AttributeValue("Dimensions", "8.5 x 11.0 x 0.5"),
            //        DataType.Number.AttributeValue("PageCount", "500"),
            //        DataType.Boolean.AttributeValue("InPublication", true),
            //        DataType.String.AttributeValue("ProductCategory", "Book")
            //        )
            //    );
        }

        private async Task AddBooksAsync()
        {
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

            await dynamoDbClient.CreateItem("ProductCatalog",
                _ => _.AttributeValueDictionary(
                    DataType.Number.AttributeValue("Id", "101"),
                    DataType.String.AttributeValue("Title", "Book 101 Title"),
                    DataType.String.AttributeValue("ISBN", "111-1111111111"),
                    DataType.StringSet.AttributeValue("Authors", new List<string> { "Author 1" }),
                    DataType.Number.AttributeValue("Price", "-2"),
                    DataType.String.AttributeValue("Dimensions", "8.5 x 11.0 x 0.5"),
                    DataType.Number.AttributeValue("PageCount", "500"),
                    DataType.Boolean.AttributeValue("InPublication", true),
                    DataType.String.AttributeValue("ProductCategory", "Book")
                    )
                );

            await dynamoDbClient.CreateItem("ProductCatalog",
                _ => _.AttributeValueDictionary(
                    DataType.Number.AttributeValue("Id", "102"),
                    DataType.String.AttributeValue("Title", "Book 102 Title"),
                    DataType.String.AttributeValue("ISBN", "222-2222222222"),
                    DataType.StringSet.AttributeValue("Authors", new List<string> { "Author 1", "Author 2" }),
                    DataType.Number.AttributeValue("Price", "20.00"),
                    DataType.String.AttributeValue("Dimensions", "8.5 x 11.0 x 0.8"),
                    DataType.Number.AttributeValue("PageCount", "600"),
                    DataType.Boolean.AttributeValue("InPublication", true),
                    DataType.String.AttributeValue("ProductCategory", "Book")
                    )
                );

            await dynamoDbClient.CreateItem("ProductCatalog",
                _ => _.AttributeValueDictionary(
                    DataType.Number.AttributeValue("Id", "103"),
                    DataType.String.AttributeValue("Title", "Book 103 Title"),
                    DataType.String.AttributeValue("ISBN", "333-3333333333"),
                    DataType.StringSet.AttributeValue("Authors", new List<string> { "Author 1", "Author 2", "Author 3" }),
                    DataType.Number.AttributeValue("Price", "2000"),
                    DataType.String.AttributeValue("Dimensions", "8.5 x 11.0 x 1.5"),
                    DataType.Number.AttributeValue("PageCount", "700"),
                    DataType.Boolean.AttributeValue("InPublication", true),
                    DataType.String.AttributeValue("ProductCategory", "Book")
                    )
                );
        }

        private void CreateTables()
        {
            // CreateTableProductCatalog();
            dynamoDbClient.TableExists("ProductCatalog").ContinueWith(checkTask =>
            {
                if (!checkTask.Result)
                    dynamoDbClient.CreateTable("ProductCatalog",
                        _ => _.AttributeDefinitionList(("Id", "N")),
                        _ => _.KeySchemaElementList(("Id", "HASH")),
                        10, 5);
            });

            // CreateTableForum();
            dynamoDbClient.TableExists("Forum").ContinueWith(checkTask =>
            {
                if (!checkTask.Result)
                    dynamoDbClient.CreateTable("Forum",
                        _ => _.AttributeDefinitionList(("Name", "S")),
                        _ => _.KeySchemaElementList(("Name", "HASH")),
                        10, 5);
            });

            // CreateTableThread()
            dynamoDbClient.TableExists("Thread").ContinueWith(checkTask =>
            {
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