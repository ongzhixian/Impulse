namespace Impulse.Applications
{
    using Impulse.DataStores.MongoDb;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;

    public class DummyMongoDbClientApplication : IDummyApplication
    {
        private readonly ILogger logger;
        private readonly IConfiguration configuration;
        private readonly IMongoDbClient mongoDbClient;

        public DummyMongoDbClientApplication(ILogger<DummyAwsClientApplication> logger, IConfiguration configuration, IMongoDbClient mongoDbClient)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            this.mongoDbClient = mongoDbClient ?? throw new ArgumentNullException(nameof(mongoDbClient));

            // TODO: To improve! Checking if connectionstring exists; can connect, ..etc...
            string connectionString = configuration["DataStores:MongoDb:Cluster0"];
            this.mongoDbClient.Init(connectionString);
        }


        public Task Run(string[] args)
        {
            return Task.Run(() =>
            {
                // DemoInsert();

                // CrudInsertDemo();

                // CrudAddDocument();

                // CrudAddDocuments();

                //this.mongoDbClient.AddDocument("emptool", "inventory", );

                IList<MongoDB.Bson.BsonDocument> s = this.mongoDbClient.GetDocument("emptool", "inventory");

                string sa = "";

                //System.Data.Common.DbDataRecord
                //System.Data.DataRow
                //System.Data.DataTable
                //System.Collections.ObjectModel.
                

            });

        } // Run(...)

        private void CrudAddDocuments()
        {
            var a = new[]
            {
                    new {item = "journal"   , qty= 25, status="A", size = new { h = 28.0M, w = 35.5M, uom = "cm" } },
                    new {item = "notebook"  , qty= 50, status="A", size = new { h = 8.5M, w = 11M, uom = "in" } },
                    new {item = "paper"  , qty= 100, status="D", size = new { h = 8.5M, w = 11M, uom = "in" } },
                    new {item = "planner"  , qty= 75, status="D", size = new { h = 22.85M, w = 30M, uom = "cm" } },
                    new {item = "postcard"  , qty= 45, status="A", size = new { h = 10M, w = 15.25M, uom = "cm" } },
                };

            var x = a.ToCompatDictionaryList();

            this.mongoDbClient.AddDocuments("emptool", "inventory", x);
        }

        private void CrudAddDocument()
        {
            var a = new
            {
                item = "canvas",
                qty = 223,
                tags = new[] { "cotton" },
                size = new { h = 28, w = 35.5, uom = "cm" }
            };

            var x = a.ToCompatDictionary();

            this.mongoDbClient.AddDocument("emptool", "inventory", x);
        }

        private void CrudInsertDemo()
        {
            Dictionary<string, object> doc = new Dictionary<string, object>
                {
                    { "item", "canvas" },
                    { "qty", 200 },
                    { "scores", new List<Dictionary<string, object>>
                        {
                            new Dictionary<string, object>{ {   "type", "exam" }, {   "score", 60 } },
                            new Dictionary<string, object>{ {   "type", "quiz" }, {   "score", 50 } },
                            new Dictionary<string, object>{ {   "type", "assignment1" }, {   "score", 43 } },
                        }
                    },
                    //{ "size", new Dictionary<string,object>{ { "h", 28 }, { "w", 35.5 }, { "uom", "cm" } } },
                    { "tags",  new List<string>{ "asd" , "asd"} }
                };

            //collection.InsertOne(document);
            this.mongoDbClient.AddDocument("emptool", "inventory", doc);

        }

        private void DemoInsert()
        {
            //this.mongoDbClient.SetDatabase("emptool");
            // this.mongoDbClient.AddDocument("emptool", "student");


            //var document = new BsonDocument
            //{
            //    { "student_id", 10000 },
            //    { "scores", new BsonArray
            //        {
            //        new BsonDocument{ {"type", "exam"}, {"score", 88.12334193287023 } },
            //        new BsonDocument{ {"type", "quiz"}, {"score", 74.92381029342834 } },
            //        new BsonDocument{ {"type", "homework"}, {"score", 89.97929384290324 } },
            //        new BsonDocument{ {"type", "homework"}, {"score", 82.12931030513218 } }
            //        }
            //    },
            //    { "class_id", 480}
            //};

            //object x = new {
            //    student_id = 30001,
            //    class_id = 300,
            //    scores = new []
            //    {
            //        new { type = "exam", score = 94}
            //    }
            //};

            byte[] imageBytes = System.IO.File.ReadAllBytes(@"D:\data\pictures\test-image.jpg");
            byte[] pdfBytes = System.IO.File.ReadAllBytes(@"D:\data\pictures\TheEvidenceNoNaturalEvol.pdf");



            Dictionary<string, object> doc = new Dictionary<string, object>
                {
                    { "student_id", 50001 },
                    { "class_id", 500 },
                    { "scores", new List<Dictionary<string, object>>
                        {
                            new Dictionary<string, object>{ {   "type", "exam" }, {   "score", 60 } },
                            new Dictionary<string, object>{ {   "type", "quiz" }, {   "score", 50 } },
                            new Dictionary<string, object>{ {   "type", "assignment1" }, {   "score", 43 } },
                        }

                    },
                    { "files", new List<Dictionary<string, object>>
                        {
                            new Dictionary<string, object>{ {   "type", "jpg" }, { "filename", "test-image.jpg" }, {   "fileBytes", imageBytes } },
                            new Dictionary<string, object>{ {   "type", "pdf" }, { "filename", "TheEvidenceNoNaturalEvol.pdf" }, {   "fileBytes", pdfBytes } },
                        }
                    }
                };

            this.mongoDbClient.AddDocument("emptool", "student", doc);
        }

    } // public class DummyMongoDbClientApplication : IDummyApplication

} // namespace Impulse.Applications