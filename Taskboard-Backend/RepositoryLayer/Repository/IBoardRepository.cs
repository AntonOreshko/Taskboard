using DomainModels.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository
{
    public interface IBoardRepository : IRepository<Board>
    {
        Task<IEnumerable<Board>> GetByUser(long userId);
    }
}
