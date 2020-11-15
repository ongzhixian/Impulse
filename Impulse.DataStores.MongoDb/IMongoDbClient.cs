namespace Impulse.DataStores.MongoDb
{
    public interface IMongoDbClient
    {
        void Init(string connectionString);
        void SetDatabase(string databaseName);

        void AddDocument(string databaseName, string collectionName);


    }
}