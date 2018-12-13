﻿using DomainModels.Interfaces;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.EntityFramework.Context;
using RepositoryLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryLayer.EntityFramework
{
    public class EfRepository<T> : IRepository<T> where T : class, IDatabaseItem
    { 
        protected readonly TaskboardContext Context;

        protected readonly DbSet<T> Entities;

        public IQueryable<T> Source
        {
            get
            {
                return Entities;
            }
        }

        public EfRepository(TaskboardContext context)
        {
            Context = context;
            Entities = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Entities.ToListAsync();
        }

        public virtual async Task<T> GetAsync(long id)
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
