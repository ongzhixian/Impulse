using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

namespace Impulse.AngularHost.Controllers
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        [HttpGet("[action]")]
        public void Add()
        {
            using (var connection = new SqliteConnection("Data Source=./data/books.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
CREATE TABLE 'book' (
	'id'	INTEGER,
	'title'	TEXT,
	'url'	TEXT,
	PRIMARY KEY('id')
);
                ";
                //command.Parameters.AddWithValue("$id", 1);
                command.ExecuteNonQuery();

                // using (var reader = command.ExecuteNonQuery())
                // {
                //     while (reader.Read())
                //     {
                //         var name = reader.GetString(0);

                //         Console.WriteLine($"Hello, {name}!");
                //     }
                // }
            }
        }

    }
}
