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

        Task<TableDescription> GetTableDescription(string tableName);

        Task SaveBook();
    }
}