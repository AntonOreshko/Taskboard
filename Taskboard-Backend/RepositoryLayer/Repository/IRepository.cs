using DomainModels.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository
{
    public interface IRepository<T> where T : IDatabaseItem
    {
        IQueryable<T> Source { get; }

        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetAsync(long id);

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
