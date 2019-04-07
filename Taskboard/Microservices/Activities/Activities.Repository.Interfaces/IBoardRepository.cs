using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Activities.DomainModels.Models;
using Common.Repository.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace Activities.Repository.Interfaces
{
    public interface IBoardRepository: IMongoDbRepository<Board>
    {
        Task<IEnumerable<Board>> GetByUserId(Guid userId);

        Task InsertTaskAsync(Guid boardId, DomainModels.Models.Task task);

		Task UpdateTaskAsync(Guid boardId, DomainModels.Models.Task task);

		Task RemoveTaskAsync(Guid boardId, Guid taskId);
    }
}
