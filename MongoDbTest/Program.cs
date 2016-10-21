using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //var client = new MongoClient(); // "mongodb://localhost:27017,localhost:27018,localhost:27019");

            //var database = client.GetDatabase("foo");

            //var collection = database.GetCollection<BsonDocument>("bar");

            var document = new BsonDocument
            {
                { "name", "MongoDB" },
                { "type", "Database" },
                { "count", 1 },
                { "info", new BsonDocument
                    {
                        { "x", 203 },
                        { "y", 102 }
                    }
                }
            };

            //collection.InsertOneAsync(document);

            var documents = Enumerable.Range(0, 100).Select(i => new BsonDocument("counter", i));

            //collection.InsertMany(documents);

            //var count = collection.Count(new BsonDocument());

        }
    }
}
