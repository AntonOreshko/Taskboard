using DomainModels.Interfaces;
using RepositoryLayer.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Interfaces
{
    public interface IDatabaseItemService<T> where T : class, IDatabaseItem
    {
        IRepository<T> Repository { get; set; }

        Task<IEnumerable<T>> GetAll();

        Task<T> Get(long id);

        Task Add(T item);

        Task Add(IEnumerable<T> items);

        Task Remove(T item);

        Task Remove(IEnumerable<T> items);

        Task Change(T item);

        Task Change(IEnumerable<T> items);

        Task Clear();
    }
}
