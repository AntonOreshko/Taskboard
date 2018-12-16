using System.Collections.Generic;
using DomainModels.Models;

namespace RepositoryLayer.Repository
{
    public interface ITaskRepository : IRepository<Task>
    {
        System.Threading.Tasks.Task<IEnumerable<Task>> GetByBoard(long userId, long boardId);
    }
}
