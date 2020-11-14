using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Amazon.Runtime;
using Impulse.Common.Extensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Impulse.CloudServices.Aws.DynamoDb
{
    public class Client : IClient
    {
        private readonly ILogger logger;
        //private readonly AmazonDynamoDBConfig dynamoDBConfig;
        private readonly AmazonDynamoDBClient dynamoDbClient;
        private readonly DynamoDBContext dynamoDbContext;

        public Client(ILogger<Client> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));

            // TODO: If we want to use local development instance of DynamoDB, we will need this
            //dynamoDBConfig = new AmazonDynamoDBConfig();

            dynamoDbClient = new AmazonDynamoDBClient();
            dynamoDbContext = new DynamoDBContext(dynamoDbClient);

            logger.LogInformation($"DynamoDB constructor");
        }

        public List<KeySchemaElement> KeySchemaElementList(params (string name, string keyType)[] nameKeyTypes)
        {
            return new List<KeySchemaElement>(
                from keyValuePair in nameKeyTypes
                select new KeySchemaElement
                {
                    AttributeName = keyValuePair.name,
                    KeyType = keyValuePair.keyType
                });
        }

        public List<AttributeDefinition> AttributeDefinitionList(params (string name, string dataType)[] nameDataTypes)
        {

            return new List<AttributeDefinition>(
                from keyValuePair in nameDataTypes
                select new AttributeDefinition
                {
                    AttributeName = keyValuePair.name,
                    AttributeType = keyValuePair.dataType
                });

            //List<AttributeDefinition> tableAttributes = new List<AttributeDefinition>()

            //foreach (var keyValuePair in keyValuePairs)
            //{
            //    tableAttributes.Add(new AttributeDefinition { AttributeName = keyValuePair.key, AttributeType = keyValuePair.value });
            //}

            //IEnumerable<AttributeDefinition> x = from keyValuePair in keyValuePairs
            //                                     select new AttributeDefinition
            //                                     {
            //                                         AttributeName = keyValuePair.key,
            //                                         AttributeType = keyValuePair.value
            //                                     };

            //return tableAttributes;
        }

        public AttributeValue MapAttributeValue(string dataType, object dataValue)
        {
            try
            {
                switch (dataType.ToUpperInvariant())
                {
                    case "B":
                        return new AttributeValue { B = (MemoryStream)dataValue };
                    case "BOOL":
                        return new AttributeValue { BOOL = (bool)dataValue };
                    case "BS":
                        return new AttributeValue { BS = (List<MemoryStream>)dataValue };
                    case "L":
                        return new AttributeValue { L = (List<AttributeValue>)dataValue };
                    case "M":
                        return new AttributeValue { M = (Dictionary<string, AttributeValue>)dataValue };
                    case "N":
                        return new AttributeValue { N = (string)dataValue };
                    case "NULL":
                        return new AttributeValue { NULL = (bool)dataValue };
                    case "S":
                        return new AttributeValue { S = (string)dataValue };
                    case "SS":
                        return new AttributeValue { SS = (List<string>)dataValue };
                    default:
                        throw new ArgumentOutOfRangeException(nameof(dataType));
                }
            }
            catch (Exception e)
            {
                logger.LogError(e, "{functionName} {dataType} {dataValue}", nameof(MapAttributeValue), dataType, dataValue);
                throw;
            }
        }

        public Dictionary<string, AttributeValue> AttributeValueDictionary(params (string name, string dataType, object dataValue)[] nameAttributeValues)
        {
            return nameAttributeValues.ToDictionary(_ => _.name, _ => MapAttributeValue(_.dataType, _.dataValue));
        }

        public async Task<bool> TableExists(string tableName)
        {
            logger.LogInformation(LoggingLayout.StartOperation, Operation.CheckIfExist, ItemType.Table, tableName, OperationState.Start);

            ListTablesResponse response = await dynamoDbClient.ListTablesAsync();

            bool result = response.TableNames.Contains(tableName);

            logger.LogInformation(LoggingLayout.EndOperation, Operation.CheckIfExist, ItemType.Table, tableName, OperationState.End, result.AsExists());

            return result;
        }

        public async Task<bool> CreateTable(string tableName,
            Func<IClient, List<AttributeDefinition>> fnAttributeDefinitionList,
            Func<IClient, List<KeySchemaElement>> fnKeySchemaElementList,
            long readCapacityUnits, long writeCapacityUnits)
        {
            logger.LogInformation(LoggingLayout.StartOperation, Operation.Create, ItemType.Table, tableName, OperationState.Start);

            bool result = await CreateTable(
                tableName,
                fnAttributeDefinitionList.Invoke(this),
                fnKeySchemaElementList.Invoke(this),
                new ProvisionedThroughput(readCapacityUnits, writeCapacityUnits));

            logger.LogInformation(LoggingLayout.EndOperation, Operation.Create, ItemType.Table, tableName, OperationState.End, result.AsSuccess());

            return result;
        }

        public async Task<bool> CreateTable(
            string tableName,
            List<AttributeDefinition> tableAttributes,
            List<KeySchemaElement> tableKeySchema,
            ProvisionedThroughput provisionedThroughput)
        {
            bool response = true;

            CreateTableRequest request = new CreateTableRequest
            {
                TableName = tableName,
                AttributeDefinitions = tableAttributes,
                KeySchema = tableKeySchema,
                ProvisionedThroughput = provisionedThroughput
            };

            try
            {
                CreateTableResponse createTableResponse = await dynamoDbClient.CreateTableAsync(request);
            }
            catch (Exception)
            {
                response = false;
            }

            return response;
        }

        public async Task<bool> DeleteTable(string tableName)
        {
            logger.LogInformation(LoggingLayout.StartOperation, Operation.Delete, ItemType.Table, tableName, OperationState.Start);

            bool response = true;

            try
            {
                DeleteTableResponse deleteTableResponse = await dynamoDbClient.DeleteTableAsync(tableName);
            }
            catch (Exception)
            {
                response = false;
            }

            logger.LogInformation(LoggingLayout.EndOperation, Operation.Delete, ItemType.Table, tableName, OperationState.End, response.AsSuccess());

            return response;
        }

        public async Task<TableDescription> GetTableDescription(string tableName)
        {
            TableDescription result = null;

            // If the table exists, get its description.
            try
            {
                var response = await dynamoDbClient.DescribeTableAsync(tableName);
                result = response.Table;
            }
            catch (Exception)
            {
            }

            return result;
        }

        public async Task<bool> CreateItem(string tableName, Func<IClient, Dictionary<string, AttributeValue>> fnAttributeValueDictionary)
        {
            logger.LogInformation(LoggingLayout.StartOperation, Operation.CreateItem, ItemType.Table, tableName, OperationState.Start);

            bool result = false;

            PutItemRequest request = null;

            try
            {
                request = new PutItemRequest
                {
                    TableName = tableName,
                    Item = fnAttributeValueDictionary.Invoke(this)
                };

                PutItemResponse response = await dynamoDbClient.PutItemAsync(request);

                result = true;
            }
            catch (Exception e)
            {
                logger.LogError(e, "Unknown exception");
            }

            logger.LogInformation(LoggingLayout.EndOperation, Operation.CreateItem, ItemType.Table, tableName, OperationState.End, result.AsSuccess());

            return result;
        }

        public async Task Save<T>(T item)
        {
            logger.LogInformation(LoggingLayout.StartOperation, Operation.CreateItem, ItemType.Table, typeof(T).Name, OperationState.Start);

            bool result = false;

            try
            {
                using (DynamoDBContext context = new DynamoDBContext(dynamoDbClient))
                {
                    await context.SaveAsync(item);

                    result = true;
                }
            }
            catch (AmazonDynamoDBException e) { logger.LogError(e, "AmazonDynamoDBException"); }
            catch (AmazonServiceException e) { logger.LogError(e, "AmazonServiceException"); }
            catch (Exception e) { logger.LogError(e, "Unknown exception"); }

            logger.LogInformation(LoggingLayout.EndOperation, Operation.CreateItem, ItemType.Table, typeof(T).Name, OperationState.End, result.AsSuccess());
        }

        public void GetItem(string tableName,
            Func<IClient, Dictionary<string, AttributeValue>> fnKey, 
            string projectionExpression,
            bool consistentRead = true
            )
        {
            var request = new GetItemRequest
            {
                TableName = tableName,
                Key = new Dictionary<string, AttributeValue>()
                {
                    { "Id", new AttributeValue {
                          N = "1000"
                      } }
                },
                ProjectionExpression = "Id, ISBN, Title, Authors",
                ConsistentRead = consistentRead
            };

            Task<GetItemResponse> response = dynamoDbClient.GetItemAsync(request);

            // Check the response.
            Dictionary<string, AttributeValue> attributeList = response.Result.Item; // attribute list in the response.

            //return attributeList;
        }

        public async Task<Document> GetDocumentAsync(string tableName, string documentKey)
        {
            Table table = Table.LoadTable(dynamoDbClient, new TableConfig(tableName));

            return await table.GetItemAsync(new Primitive(documentKey, true));
        }

        // Not in interface
        ////////////////////////////////////////

        //public async Task SaveBook()
        //{
        //    try
        //    {
        //        DynamoDBContext context = new DynamoDBContext(dynamoDBClient);

        //        Book myBook = new Book
        //        {
        //            Id = 1001,
        //            Title = "object persistence-AWS SDK for.NET SDK-Book 1001",
        //            ISBN = "111-1111111001",
        //            BookAuthors = new List<string> { "Author 1", "Author 2" },
        //        };

        //        // Save the book.
        //        await context.SaveAsync(myBook);
        //    }
        //    catch (AmazonDynamoDBException e) { logger.LogError(e, "AmazonDynamoDBException"); }
        //    catch (AmazonServiceException e) { logger.LogError(e, "AmazonServiceException"); }
        //    catch (Exception e) { logger.LogError(e, "Unknown exception"); }

        //}

        //public async Task<Document> ReadingMovie_async(int year, string title)
        //{
        //    Table table = Table.LoadTable(dynamoDBClient, "ProductCatalog");



        //    // Create Primitives for the HASH and RANGE portions of the primary key
        //    Primitive hash = new Primitive(year.ToString(), true);
        //    Primitive range = new Primitive(title, false);

        //    try
        //    {
        //        table.GetItemAsync(hash, range, )
        //        var movieItem = await MoviesTable.GetItemAsync(hash, range, Token);
        //        return movieItem;
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}

        public async Task<bool> SaveDocumentAsync(string tableName, Document document)
        {
            //Table table = Table.LoadTable(dynamoDBClient, "ProductCatalog");

            //var book1 = new Document();
            //book1["Id"] = 101;
            //book1["Title"] = "Book 101 Title";
            //book1["ISBN"] = "111-1111111111";
            //book1["Authors"] = new List<string> { "Author 1" };
            //book1["Price"] = -2; // *** Intentional value. Later used to illustrate scan.
            //book1["Dimensions"] = "8.5 x 11.0 x 0.5";
            //book1["PageCount"] = 500;
            //book1["InPublication"] = true;
            //book1["ProductCategory"] = "Book";

            ////productCatalogTable.PutItem(book1);
            //table.PutItemAsync()

            //book1.Add("asd", DynamoDBEntry)

            bool result = false;

            try
            {
                Table table = Table.LoadTable(dynamoDbClient, tableName);

                document = await table.PutItemAsync(document);

                result = true;
            }
            catch (Exception ex)
            {
                //Console.WriteLine("      FAILED to write the new movie, because:\n       {0}.", ex.Message);
            }

            return result;
        }

    }
}
