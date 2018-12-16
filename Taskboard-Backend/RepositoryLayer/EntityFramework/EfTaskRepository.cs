using System.Collections.Generic;
using System.Linq;
using DomainModels.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.EntityFramework.Context;
using RepositoryLayer.Repository;

namespace RepositoryLayer.EntityFramework
{
    public class EfTaskRepository : EfRepository<Task>, ITaskRepository
    {
        public EfTaskRepository(TaskboardContext context) : base(context)
        {

        }

        public async System.Threading.Tasks.Task<IEnumerable<Task>> GetByBoard(long userId, long boardId)
        {
            return await Entities.Where(t => t.BoardId == boardId && t.CreatedById == userId).ToListAsync();
        }
    }
}
