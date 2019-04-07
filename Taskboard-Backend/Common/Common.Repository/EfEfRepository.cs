using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.DomainModels.Interfaces;
using Common.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Common.Repository
{
    public class EfEfRepository<T> : IEfRepository<T> where T : class, IPersistentEntity
    {
        protected readonly DbContext Context;

        protected readonly DbSet<T> Entities;

        public IQueryable<T> Source => Entities;

        public EfEfRepository(DbContext context)
        {
            Context = context;
            Entities = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Entities.ToListAsync();
        }

        public virtual async Task<T> GetAsync(Guid id)
        {
            return await Entities.SingleOrDefaultAsync(s => s.Id == id);
        }

        public virtual async Task<bool> ContainsAsync(T entity)
        {
            return await Entities.ContainsAsync(entity);
        }

        public virtual async Task InsertAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await Entities.AddAsync(entity);
        }

        public virtual async Task InsertRangeAsync(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            await Entities.AddRangeAsync(entities);
        }

        public virtual void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Entities.Update(entity);
        }

        public virtual void UpdateRange(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            Entities.UpdateRange(entities);
        }

        public virtual void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            Entities.Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }
            Entities.RemoveRange(entities);
        }

        public virtual void Clear()
        {
            Context.RemoveRange(Entities);
        }

        public virtual async Task SaveChangesAsync()
        {
            await Context.SaveChangesAsync();
        }

    }
}
