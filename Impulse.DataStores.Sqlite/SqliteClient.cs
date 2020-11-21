using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Logging;
using System;

namespace Impulse.DataStores.Sqlite
{

    public class SqliteClient : ISqliteClient
    {
        private readonly ILogger logger;
        private string connectionString;
        private Microsoft.Data.Sqlite.SqliteConnection connection;

        public SqliteClient(ILogger<SqliteClient> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));

            logger.LogInformation("In SqliteClient constructor");
        }

        public void Init(string connectionString)
        {
            // https://docs.microsoft.com/en-us/dotnet/standard/data/sqlite/connection-strings#examples
            // Data Source=Application.db;Cache=Shared              // Basic
            // Data Source=Encrypted.db;Password=MyEncryptionKey    // Encrypted
            // Data Source=Reference.db;Mode=ReadOnly               // Read-only
            // Data Source=:memory:                                 // In-memory
            // Data Source=Sharable;Mode=Memory;Cache=Shared        // Sharable in-memory

            this.connectionString = connectionString;
        }

        public void CreateDatabase()
        {
            using (Microsoft.Data.Sqlite.SqliteConnection connection = new Microsoft.Data.Sqlite.SqliteConnection(connectionString))
            {
                connection.Open();
            }
        }

        public void CreateTable()
        {
            using (Microsoft.Data.Sqlite.SqliteConnection connection = new Microsoft.Data.Sqlite.SqliteConnection(connectionString))
            {
                connection.Open();

                SqliteCommand cmd = connection.CreateCommand();
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS favorite_beers(name VARCHAR(50))";
                cmd.ExecuteNonQuery();
            }
        }

        public void DropTable()
        {
            using (Microsoft.Data.Sqlite.SqliteConnection connection = new Microsoft.Data.Sqlite.SqliteConnection(connectionString))
            {

                SqliteCommand cmd = connection.CreateCommand();
                cmd.CommandText = "DROP TABLE IF EXISTS favorite_beers";

                connection.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void SeedData()
        {
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                using (SqliteTransaction transaction = connection.BeginTransaction())
                {
                    SqliteCommand cmd = connection.CreateCommand();

                    cmd.CommandText = "INSERT INTO favorite_beers VALUES('LAGUNITAS IPA')";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "INSERT INTO favorite_beers VALUES('JAI ALAI IPA')";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "INSERT INTO favorite_beers VALUES('RANGER IPA')";
                    cmd.ExecuteNonQuery();

                    transaction.Commit();
                }
            }
        }

        public void GetData()
        {
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                var selectCmd = connection.CreateCommand();
                selectCmd.CommandText = "SELECT name FROM favorite_beers";

                connection.Open();
                using (var reader = selectCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var message = reader.GetString(0);
                        Console.WriteLine(message);
                    }
                }

            }

            
        }




    }
}
