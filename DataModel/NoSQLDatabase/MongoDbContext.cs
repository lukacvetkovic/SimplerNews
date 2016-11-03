using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using BusinessEntities.BusinessModels;

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
            var collection = Db.GetCollection<TEntity>(typeof(TEntity).Name.ToLower() + "s");

            if (typeof(TEntity) == typeof(YoutubeChannel))
            {
                var options = new CreateIndexOptions() { Unique = true };
                var field = new StringFieldDefinition<TEntity>("Name");
                var indexDefinition = new IndexKeysDefinitionBuilder<TEntity>().Ascending(field);

                collection.Indexes.CreateOne(indexDefinition, options);
            }
            
            return collection;
        }
    }
}
