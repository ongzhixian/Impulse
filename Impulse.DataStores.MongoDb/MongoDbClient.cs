using MongoDB.Driver;
using System;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;

namespace Impulse.DataStores.MongoDb
{
    public class MongoDbClient : IMongoDbClient
    {
        private readonly ILogger logger;
        private MongoClient client = null;
        //private IMongoDatabase database;

        public MongoDbClient(ILogger<MongoDbClient> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));

            logger.LogInformation("In MongoDbClient constructor");
        }

        public void Init(string connectionString)
        {
            if (client == null)
            {
                client = new MongoClient(connectionString);
            }

            
        }

        public void SetDatabase(string databaseName)
        {
            logger.LogInformation(LoggingLayout.StartOperation, "Connect", "MongoDb", "cluster0", "start");

            bool result = true;

            try
            {
                var database = client.GetDatabase(databaseName);
            }
            catch (Exception)
            {
                result = false;
            }

            //logger.LogInformation(LoggingLayout.EndOperation, Operation.Delete, ItemType.Table, tableName, OperationState.End, result.AsSuccess());

            //return response;

            //MongoClient dbClient = new MongoClient("<<YOUR ATLAS CONNECTION STRING>>");

            //var dbList = dbClient.ListDatabases().ToList();

            //Console.WriteLine("The list of databases on this server is: ");
            //foreach (var db in dbList)
            //{
            //    Console.WriteLine(db);
            //}

        } // void Connect()


        public void AddDocument(string databaseName, string collectionName)
        {
            IMongoDatabase database = client.GetDatabase(databaseName);

            IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>(collectionName);

            var document = new BsonDocument
            {
                { "student_id", 10000 },
                { "scores", new BsonArray
                    {
                    new BsonDocument{ {"type", "exam"}, {"score", 88.12334193287023 } },
                    new BsonDocument{ {"type", "quiz"}, {"score", 74.92381029342834 } },
                    new BsonDocument{ {"type", "homework"}, {"score", 89.97929384290324 } },
                    new BsonDocument{ {"type", "homework"}, {"score", 82.12931030513218 } }
                    }
                },
                { "class_id", 480}
            };

            
            collection.InsertOne(document);

            
        }

    } // class MongoDbClient : IMongoDbClient
} // namespace Impulse.DataStores.MongoDb
