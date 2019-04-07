using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Common.MongoDb
{
    public class MongoDbContext<T>
    {
        protected readonly IMongoDatabase Database = null;

        public MongoDbContext(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            Database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<T> Items => Database.GetCollection<T>(typeof(T).Name);
    }
}