using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DataModel.NoSQLDatabase
{
    public class MongoDbContext
    {
        String ConnectionString =
            "mongodb://simplernews:JtYNzd5IBlwj5ZuIPHxHuJSaY0WhFV3JZEj8LnjZOyDIpWrPKGVMaHiaTwJfyXnCSkM4ZzJsZZL3Gas8w2h4Og==@simplernews.documents.azure.com:10250/?ssl=true";

        private static MongoDbContext _instance;
        public readonly IMongoDatabase Db;

        private MongoDbContext()
        {
            var client = new MongoClient(ConnectionString);
            Db = client.GetDatabase("SimplerNews");
        }

        public static MongoDbContext GetInstanceInstance => _instance ?? (_instance = new MongoDbContext());

        /// <summary>
        /// The private GetCollection method
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public IMongoCollection<TEntity> GetCollection<TEntity>()
        {
            return Db.GetCollection<TEntity>(typeof(TEntity).Name.ToLower() + "s");
        }
    }
}
