using System.Collections.Generic;
using System.Threading.Tasks;
using DomainModels.Models;

namespace RepositoryLayer.Repository
{
    public interface ISubtaskRepository: IRepository<Subtask>
    {
        Task<IEnumerable<Subtask>> GetByTask(long userId, long taskId);
    }
}
