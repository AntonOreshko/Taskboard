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

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Context.Items
                .Find(_ => true)
                .ToListAsync();
        }

        public virtual async Task<T> GetAsync(Guid id)
        {
            return await Context.Items
                .Find(item => item.Id == id)
                .FirstOrDefaultAsync();
        }

        public virtual async Task InsertAsync(T entity)
        {
            await Context.Items.InsertOneAsync(entity);
        }

        public virtual async Task InsertRangeAsync(IEnumerable<T> entities)
        {
            await Context.Items.InsertManyAsync(entities);
        }

        public virtual async Task UpdateAsync(T entity)
        {
            await Context.Items
                .ReplaceOneAsync(
                    item => item.Id.Equals(entity.Id),
                    entity,
                    new UpdateOptions { IsUpsert = true });
        }

        public virtual async Task RemoveAsync(Guid id)
        {
            await Context.Items
                .DeleteOneAsync(Builders<T>.Filter.Eq("Id", id));
        }


        public virtual async Task ClearAsync()
        {
            await Context.Items
                .DeleteManyAsync(_ => true);
        }
    }
}