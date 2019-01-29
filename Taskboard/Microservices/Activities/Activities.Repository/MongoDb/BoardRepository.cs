using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Activities.DomainModels.Models;
using Activities.Repository.Interfaces;
using Common.MongoDb;
using Common.Repository;
using MongoDB.Driver;

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
    }
}
