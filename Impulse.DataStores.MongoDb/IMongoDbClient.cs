namespace Impulse.DataStores.MongoDb
{
    using MongoDB.Bson;
    using System.Collections.Generic;

    public interface IMongoDbClient
    {
        void Init(string connectionString);
        void SetDatabase(string databaseName);

        void AddDocument(string databaseName, string collectionName, IDictionary<string, object> document);

        void AddDocuments(string databaseName, string collectionName, IList<IDictionary<string, object>> docObjects);

        IList<BsonDocument> GetDocuments(string databaseName, string collectionName);

        IList<BsonDocument> GetDocument(string databaseName, string collectionName);
    }
}