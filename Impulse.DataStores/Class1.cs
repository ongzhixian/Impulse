using Microsoft.Extensions.Logging;
using System;

namespace Impulse.DataStores
{

    public interface IDataStore
    {

    }

    public interface IDataStoreClient
    {

    }
    public class DataStore : IDataStore
    {
        private readonly ILogger logger;
        IDataStoreClient client;
        public DataStore(ILogger<DataStore> logger)
        {
            //var x = new DataStore();
            //x.Configure();
            
        }

        public void Configure()
        {

        }

        public void GetDataTable(string tableName)
        {
            System.Data.DataTable dt = new System.Data.DataTable();

            // 
            //client.GetTable(tableName);

        }

        public void GetRecords(string tableName)
        {
            System.Data.DataTable dt = new System.Data.DataTable();

            // 
            //client.GetTable(tableName);

        }

        public void Get()
        {
            
        }


        //private DataStoreType? dataStoreType;
        //public DataStoreType? DataStoreType {

        //    get
        //    {
        //        return this.dataStoreType;
        //    }

        //    set
        //    {
        //        switch (value)
        //        {
        //            case DataStores.DataStoreType.Sqlite:

        //                break;
        //            default:
        //                throw new ArgumentOutOfRangeException(nameof(DataStoreType));
        //        }

        //        this.dataStoreType = value;
        //    }
        //}
    }

    public enum DataStoreType
    {
        
        Sqlite,
        MongoDb,
        DynamoDb,
        //SqlServer,
        //MySql,
        //Postgresql




    }
}
