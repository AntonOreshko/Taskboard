using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.DomainModels.Interfaces;
using Common.MongoDb;
using Common.Repository.Interfaces;
using MongoDB.Driver;

namespace Common.Repository
{
    public class MongoDbRepository<T>: IMongoDbRepository<T> where T : class, IPersistentEntity
    {
        protected readonly MongoDbContext<T> Context;

        public MongoDbRepository(MongoDbContext<T> context)
        {
            Context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Context.Items
                .Find(_ => true)
                .ToListAsync();
        }

        public async Task<T> GetAsync(Guid id)
        {
            return await Context.Items
                .Find(item => item.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task InsertAsync(T entity)
        {
            await Context.Items.InsertOneAsync(entity);
        }

        public async Task InsertRangeAsync(IEnumerable<T> entities)
        {
            await Context.Items.InsertManyAsync(entities);
        }

        public async Task UpdateAsync(T entity)
        {
            await Context.Items
                .ReplaceOneAsync(
                    item => item.Id.Equals(entity.Id),
                    entity,
                    new UpdateOptions { IsUpsert = true });
        }

        public async Task RemoveAsync(Guid id)
        {
            await Context.Items
                .DeleteOneAsync(Builders<T>.Filter.Eq("Id", id));
        }


        public async Task ClearAsync()
        {
            await Context.Items
                .DeleteManyAsync(_ => true);
        }
    }
}