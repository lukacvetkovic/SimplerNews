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
            "mongodb://localhost:27017/mydb";

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
