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

        Task TaskCreate(Guid boardId, DomainModels.Models.Task task);
    }
}
