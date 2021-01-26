namespace Impulse.Applications
{
    using Impulse.DataStores.Sqlite;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading.Tasks;

    public class DummySqliteClientApplication : IDummyApplication
    {
        private readonly ILogger logger;
        private readonly IConfiguration configuration;
        private readonly ISqliteClient sqliteClient;

        public DummySqliteClientApplication(ILogger<DummySqliteClientApplication> logger, IConfiguration configuration, ISqliteClient sqliteClient)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            this.sqliteClient = sqliteClient ?? throw new ArgumentNullException(nameof(sqliteClient));

            // TODO: To improve! Checking if connectionstring exists; can connect, ..etc...
            string connectionString = configuration["DataStores:Sqlite:DummyApplication"];
            this.sqliteClient.Init(connectionString);
        }


        public Task Run(string[] args)
        {
            return Task.Run(() =>
            {
                //sqliteClient.CreateDatabase();

                //sqliteClient.CreateTable();

                //sqliteClient.DropTable();

                //sqliteClient.SeedData();

                sqliteClient.GetData();


            });

        } // Run(...)

    } // public class DummyMongoDbClientApplication : IDummyApplication

} // namespace Impulse.Applications