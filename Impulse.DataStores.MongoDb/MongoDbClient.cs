using MongoDB.Driver;
using System;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using System.Collections.Generic;

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



        public void AddDocument(string databaseName, string collectionName, IDictionary<string, object> document)
        {
            IMongoDatabase database = client.GetDatabase(databaseName);

            IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>(collectionName);

            collection.InsertOne(new BsonDocument(document));
        }

        public void AddDocuments(string databaseName, string collectionName, IList<IDictionary<string, object>> docObjects)
        {
            IMongoDatabase database = client.GetDatabase(databaseName);

            IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>(collectionName);

            IList<BsonDocument> documents = new List<BsonDocument>();

            foreach (IDictionary<string, object> item in docObjects)
            {
                documents.Add(new BsonDocument(item));
            }

            collection.InsertMany(documents);
        }

        public IList<BsonDocument> GetDocuments(string databaseName, string collectionName)
        {
            IMongoDatabase database = client.GetDatabase(databaseName);

            IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>(collectionName);

            FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Empty;

            IList<BsonDocument> result = collection.Find(filter).ToList();

            //result[0].Elements
            //Count = 6
            //[0]: { _id = 5fb8a288381d053ee77b413a}
            //[1]: {item=canvas
            //}
            //[2]: {qty=500}
            //[3]: {scores=[{ "type" : "exam", "score" : 60 }, { "type" : "quiz", "score" : 50 }, { "type" : "assignment1", "score" : 43 }]}
            //[4]: {size={ "h" : 28, "w" : 35.5, "uom" : "cm" }}
            //[5]: {tags=[asd, asd]}

            
            return result;
        }


        public IList<BsonDocument> GetDocument(string databaseName, string collectionName)
        {
            IMongoDatabase database = client.GetDatabase(databaseName);

            IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>(collectionName);

            FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Empty;
            filter = Builders<BsonDocument>.Filter.And(filter, Builders<BsonDocument>.Filter.Eq("status", "D"));



            //Builders<BsonDocument>.Filter.Eq("status", "D");
            //Builders<BsonDocument>.Filter.Eq("status", "D");
            //Builders<BsonDocument>.Filter.Eq("item", "planner");

            //FilterDefinition nameFilter = Builders.Filter.Eq(x => x.Author, "Justine Picardie");
            //FilterDefinition inStockFilter = Builders.Filter.Eq(x => x.InStock, true);
            //FilterDefinition combineFilters = Builders.Filter.And(nameFilter, inStockFilter);


            IList<BsonDocument> result = collection.Find(filter).ToList();

            return result;

        }


        [Obsolete]
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
