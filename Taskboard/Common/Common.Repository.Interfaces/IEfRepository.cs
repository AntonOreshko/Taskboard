using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.DomainModels.Interfaces;

namespace Common.Repository.Interfaces
{
    public interface IEfRepository<T> where T : IPersistentEntity
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetAsync(Guid id);

        Task<bool> ContainsAsync(T entity);

        Task InsertAsync(T entity);

        Task InsertRangeAsync(IEnumerable<T> entities);

        void Update(T entity);

        void UpdateRange(IEnumerable<T> entities);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);

        void Clear();

        Task SaveChangesAsync();
    }
}
