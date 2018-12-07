using BusinessLayer.Services.Interfaces;
using DomainModels.Interfaces;
using RepositoryLayer.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class DatabaseItemService<T> : IDatabaseItemService<T> where T : class, IDatabaseItem
    {
        public IRepository<T> Repository { get; set; }

        public DatabaseItemService(IRepository<T> repo)
        {
            Repository = repo;
        }

        public async Task Add(T item)
        {
            await Repository.InsertAsync(item);
            await Repository.SaveChangesAsync();
        }

        public async Task Add(IEnumerable<T> items)
        {
            await Repository.InsertRangeAsync(items);
            await Repository.SaveChangesAsync();
        }

        public async Task Change(T item)
        {
            Repository.Update(item);
            await Repository.SaveChangesAsync();
        }

        public async Task Change(IEnumerable<T> items)
        {
            Repository.UpdateRange(items);
            await Repository.SaveChangesAsync();
        }

        public async Task Clear()
        {
            Repository.Clear();
            await Repository.SaveChangesAsync();
        }

        public async Task<T> Get(long id)
        {
            return await Repository.GetAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await Repository.GetAllAsync();
        }

        public async Task Remove(T item)
        {
            Repository.Remove(item);
            await Repository.SaveChangesAsync();
        }

        public async Task Remove(IEnumerable<T> items)
        {
            Repository.RemoveRange(items);
            await Repository.SaveChangesAsync();
        }
    }
}
