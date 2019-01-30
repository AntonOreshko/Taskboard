﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Activities.DomainModels.Models;
using Activities.Repository.Interfaces;
using Common.MongoDb;
using Common.Repository;
using MongoDB.Driver;
using Task = System.Threading.Tasks.Task;

namespace Activities.Repository.MongoDb
{
    public class BoardRepository : MongoDbRepository<Board>, IBoardRepository
    {
        public BoardRepository(MongoDbContext<Board> context) : base(context)
        {

        }

        public async Task<IEnumerable<Board>> GetByUserId(Guid userId)
        {
            return await Context.Items
                .Find(item => item.CreatedById == userId)
                .ToListAsync();
        }

        public override async Task UpdateAsync(Board entity)
        {
            var filter = Builders<Board>.Filter.Eq(b => b.Id, entity.Id);
            var update = Builders<Board>.Update
                .Set(b => b.Name, entity.Name)
                .Set(b => b.Description, entity.Description);

            await Context.Items.UpdateOneAsync(filter, update);
        }

        public async Task TaskCreate(Guid boardId, DomainModels.Models.Task task)
        {
            var filter = Builders<Board>.Filter.Eq(b => b.Id, boardId);
            var update = Builders<Board>.Update
                .AddToSet(f => f.Tasks, task);

            await Context.Items.UpdateOneAsync(filter, update);
        }
    }
}
