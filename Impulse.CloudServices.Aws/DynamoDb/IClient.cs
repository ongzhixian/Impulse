using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Impulse.CloudServices.Aws.DynamoDb
{
    public interface IClient
    {
        Task<bool> TableExists(string tableName);

        List<AttributeDefinition> AttributeDefinitionList(params (string name, string dataType)[] nameDataTypes);

        List<KeySchemaElement> KeySchemaElementList(params (string name, string keyType)[] nameKeyTypes);

        Dictionary<string, AttributeValue> AttributeValueDictionary(params (string name, string dataType, object dataValue)[] nameAttributeValues);

        Task<bool> CreateTable(
            string tableName,
            List<AttributeDefinition> tableAttributes,
            List<KeySchemaElement> tableKeySchema,
            ProvisionedThroughput provisionedThroughput);

        Task<bool> CreateTable(
            string tableName,
            Func<IClient, List<AttributeDefinition>> fnAttributeDefinitionList,
            Func<IClient, List<KeySchemaElement>> fnKeySchemaElementList,
            long readCapacityUnits, long writeCapacityUnits);

        Task<bool> DeleteTable(string tableName);

        Task<bool> CreateItem(string tableName, Func<IClient, Dictionary<string, AttributeValue>> fnAttributeValueDictionary);

        Task<TableDescription> GetTableDescription(string tableName);

        Task Save<T>(T item);

        Task<Document> GetDocumentAsync(string tableName, string documentKey);

        void GetItem(string tableName,
           Func<IClient, Dictionary<string, AttributeValue>> fnKey,
           string projectionExpression,
           bool consistentRead = true
           );
    }
}