using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.DomainModels.Interfaces;

namespace Common.Repository.Interfaces
{
    public interface IMongoDbRepository<T> where T : IPersistentEntity
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetAsync(Guid id);

        Task InsertAsync(T entity);

        Task InsertRangeAsync(IEnumerable<T> entities);

        Task UpdateAsync(T entity);

        Task RemoveAsync(Guid id);

        Task ClearAsync();
    }
}