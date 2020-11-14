using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Amazon.Runtime;
using Impulse.CloudServices.Aws.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Impulse.CloudServices.Aws.DynamoDb
{
    public class Client : IClient
    {
        private readonly ILogger logger;
        //private readonly AmazonDynamoDBConfig dynamoDBConfig;
        private readonly AmazonDynamoDBClient dynamoDBClient;
        private readonly DynamoDBContext dynamoDBContext;

        public Client(ILogger<Client> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));

            // TODO: If we want to use local development instance of DynamoDB, we will need this
            //dynamoDBConfig = new AmazonDynamoDBConfig();

            dynamoDBClient = new AmazonDynamoDBClient();
            dynamoDBContext = new DynamoDBContext(dynamoDBClient);

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

        public async Task<bool> TableExists(string tableName)
        {
            var response = await dynamoDBClient.ListTablesAsync();

            return response.TableNames.Contains(tableName);
        }

        public async Task<bool> CreateTable(string tableName, 
            Func<IClient, List<AttributeDefinition>> fnAttributeDefinitionList, 
            Func<IClient, List<KeySchemaElement>> fnKeySchemaElementList,
            long readCapacityUnits, long writeCapacityUnits)
        {
            return await CreateTable(
                tableName,
                fnAttributeDefinitionList.Invoke(this),
                fnKeySchemaElementList.Invoke(this),
                new ProvisionedThroughput(readCapacityUnits, writeCapacityUnits));
        }

        public async Task<bool> CreateTable(
            string tableName, 
            List<AttributeDefinition> tableAttributes, 
            List<KeySchemaElement> tableKeySchema, 
            ProvisionedThroughput provisionedThroughput)
        {
            bool response = true;

            // Build the 'CreateTableRequest' structure for the new table
            var request = new CreateTableRequest
            {
                TableName = tableName,
                AttributeDefinitions = tableAttributes,
                KeySchema = tableKeySchema,
                ProvisionedThroughput = provisionedThroughput
            };

            try
            {
                var makeTbl = await dynamoDBClient.CreateTableAsync(request);
            }
            catch (Exception)
            {
                response = false;
            }

            return response;
        }

        public async Task<TableDescription> GetTableDescription(string tableName)
        {
            TableDescription result = null;

            // If the table exists, get its description.
            try
            {
                var response = await dynamoDBClient.DescribeTableAsync(tableName);
                result = response.Table;
            }
            catch (Exception)
            {
            }

            return result;
        }


        public async Task SaveBook()
        {
            try
            {
                DynamoDBContext context = new DynamoDBContext(dynamoDBClient);

                Book myBook = new Book
                {
                    Id = 1001,
                    Title = "object persistence-AWS SDK for.NET SDK-Book 1001",
                    ISBN = "111-1111111001",
                    BookAuthors = new List<string> { "Author 1", "Author 2" },
                };

                // Save the book.
                await context.SaveAsync(myBook);
            }
            catch (AmazonDynamoDBException e) { logger.LogError(e, "AmazonDynamoDBException");}
            catch (AmazonServiceException e) { logger.LogError(e, "AmazonServiceException"); }
            catch (Exception e) { logger.LogError(e, "Unknown exception"); }

        }

    }
}
