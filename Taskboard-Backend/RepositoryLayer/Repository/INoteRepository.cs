using System.Collections.Generic;
using System.Threading.Tasks;
using DomainModels.Models;

namespace RepositoryLayer.Repository
{
    public interface INoteRepository: IRepository<Note>
    {
        Task<IEnumerable<Note>> GetByBoard(long userId, long boardId);
    }
}
