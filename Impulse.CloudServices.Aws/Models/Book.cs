﻿namespace Impulse.CloudServices.Aws.Models
{
    using Amazon.DynamoDBv2.DataModel;
    using System.Collections.Generic;

    [DynamoDBTable("ProductCatalog")]
    public class Book
    {
        [DynamoDBHashKey] //Partition key
        public int Id { get; set;}

        [DynamoDBProperty]
        public string Title { get; set; }

        [DynamoDBProperty]
        public string ISBN { get; set; }

        [DynamoDBProperty("Authors")] //String Set datatype
        public List<string> BookAuthors { get; set;}
    }
}