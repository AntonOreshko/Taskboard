using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;

namespace Common.MongoDb
{
    public static class Extensions
    {
        public static IServiceCollection AddMongoDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoDbSettings>(options =>
            {
                options.ConnectionString
                    = configuration.GetSection("MongoConnection:ConnectionString").Value;
                options.Database
                    = configuration.GetSection("MongoConnection:Database").Value;
            });

            BsonDefaults.GuidRepresentation = GuidRepresentation.CSharpLegacy;

            return services;
        }
    }
}