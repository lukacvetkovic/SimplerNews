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

        private static MongoDbHelper instance;
        private readonly MongoClient client;
        private IMongoDatabase _db;

        private MongoDbHelper()
        {
            client = new MongoClient(ConnectionString);
            _db = client.GetDatabase("SimpleNews");
        }

        public static MongoDbHelper GetInstanceInstance
        {
            get { return instance ?? (instance = new MongoDbHelper()); }
        }

        public async Task InsertData<T>(T data)
        {
            if (data != null)
            {
                var col = _db.GetCollection<BsonDocument>("News");


                await col.InsertOneAsync(data.ToBsonDocument());
            }
        }

        public async Task InsertData<T>(T[] data)
        {

            if (data != null)
            {
                var col = _db.GetCollection<BsonDocument>("News");

                List<BsonDocument> listOfBsonDocuments = new List<BsonDocument>();

                foreach (var d in data)
                {
                    listOfBsonDocuments.Add(d.ToBsonDocument());
                }

                await col.InsertManyAsync(listOfBsonDocuments);
            }
        }

        public async Task UpdateData<T>(T data, BsonObjectId _id)
        {

            if (data != null)
            {
                var col = _db.GetCollection<BsonDocument>("News");

                await col.ReplaceOneAsync(Builders<BsonDocument>.Filter.Eq("_id", _id), data.ToBsonDocument());
            }
        }

        public async Task DeleteOne<T>(BsonObjectId _id)
        {

            if (_id != null)
            {
                var col = _db.GetCollection<BsonDocument>("News");

                await col.DeleteOneAsync(Builders<BsonDocument>.Filter.Eq("_id", _id));
            }
        }

        public async Task<List<BsonDocument>> GetFiltered<T>(String column, String value)
        {
            var col = _db.GetCollection<BsonDocument>("News");
            var filter = Builders<BsonDocument>.Filter.Eq(column, value);
            var result = await col.Find(filter).ToListAsync();

            return result;
        }
    }
}
