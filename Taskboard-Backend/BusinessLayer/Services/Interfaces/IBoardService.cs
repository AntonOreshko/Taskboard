using DomainModels.Models;
using RepositoryLayer.Repository;

namespace BusinessLayer.Services.Interfaces
{
    public interface IBoardService : IDatabaseItemService<Board>
    {
        IBoardRepository BoardRepository { get; set; }
    }
}
