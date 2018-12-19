using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.EntityFramework.Context;
using RepositoryLayer.Repository;

namespace RepositoryLayer.EntityFramework
{
    public class EfSubtaskRepository : EfRepository<Subtask>, ISubtaskRepository
    {
        public EfSubtaskRepository(TaskboardContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Subtask>> GetByTask(long userId, long taskId)
        {
            return await Entities
                .Where(st => st.TaskId == taskId && st.CreatedById == userId)
                .ToListAsync();
        }
    }
}
