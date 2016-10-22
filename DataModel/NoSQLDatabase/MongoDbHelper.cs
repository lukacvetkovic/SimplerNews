using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DataModel.NoSQLDatabase
{
    public class MongoDbHelper
    {
        String ConnectionString =
            "mongodb://simplernews:JtYNzd5IBlwj5ZuIPHxHuJSaY0WhFV3JZEj8LnjZOyDIpWrPKGVMaHiaTwJfyXnCSkM4ZzJsZZL3Gas8w2h4Og==@simplernews.documents.azure.com:10250/?ssl=true";

        private static MongoDbHelper _instance;
        public readonly IMongoDatabase Db;

        private MongoDbHelper()
        {
            var client = new MongoClient(ConnectionString);
            Db = client.GetDatabase("SimplerNews");
        }

        public static MongoDbHelper GetInstanceInstance => _instance ?? (_instance = new MongoDbHelper());

        public async Task InsertData<T>(T data, string collection)
        {
            if (data != null)
            {
                var col = Db.GetCollection<BsonDocument>(collection);


                await col.InsertOneAsync(data.ToBsonDocument());
            }
        }

        public async Task InsertData<T>(T[] data, string collection)
        {

            if (data != null)
            {
                var col = Db.GetCollection<BsonDocument>(collection);

                List<BsonDocument> listOfBsonDocuments = new List<BsonDocument>();

                foreach (var d in data)
                {
                    listOfBsonDocuments.Add(d.ToBsonDocument());
                }

                await col.InsertManyAsync(listOfBsonDocuments);
            }
        }

        public async Task UpdateData<T>(T data, BsonObjectId _id, string collection)
        {

            if (data != null)
            {
                var col = Db.GetCollection<BsonDocument>(collection);

                await col.ReplaceOneAsync(Builders<BsonDocument>.Filter.Eq("_id", _id), data.ToBsonDocument());
            }
        }

        public async Task DeleteOne<T>(BsonObjectId _id, string collection)
        {

            if (_id != null)
            {
                var col = Db.GetCollection<BsonDocument>(collection);

                await col.DeleteOneAsync(Builders<BsonDocument>.Filter.Eq("_id", _id));
            }
        }

        public async Task<List<BsonDocument>> GetFiltered<T>(String column, String value, string collection)
        {
            var col = Db.GetCollection<BsonDocument>(collection);
            var filter = Builders<BsonDocument>.Filter.Eq(column, value);
            var result = await col.Find(filter).ToListAsync();

            return result;
        }
    }
}
