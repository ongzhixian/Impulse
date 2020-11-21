using System;

namespace Impulse.DataStores.Sqlite
{

    public interface ISqliteClient
    {
        void Init(string connectionString);

        void CreateDatabase();

        void CreateTable();

        void DropTable();

        void SeedData();

        void GetData();

    }

}
