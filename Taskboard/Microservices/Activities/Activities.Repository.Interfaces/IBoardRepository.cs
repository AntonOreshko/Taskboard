using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Activities.DomainModels.Models;
using Common.Repository.Interfaces;

namespace Activities.Repository.Interfaces
{
    public interface IBoardRepository: IMongoDbRepository<Board>
    {
        Task<IEnumerable<Board>> GetByUserId(Guid userId);
    }
}