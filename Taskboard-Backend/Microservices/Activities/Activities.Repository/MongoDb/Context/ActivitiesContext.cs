using Common.MongoDb;
using Microsoft.Extensions.Options;

namespace Activities.Repository.MongoDb.Context
{
    public class ActivitiesContext<T>: MongoDbContext<T>
    {
        public ActivitiesContext(IOptions<MongoDbSettings> settings) : base(settings)
        {
        }
    }
}