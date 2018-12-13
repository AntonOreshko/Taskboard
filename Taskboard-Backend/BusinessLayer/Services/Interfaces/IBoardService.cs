using DomainModels.Models;
using RepositoryLayer.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Interfaces
{
    public interface IBoardService : IDatabaseItemService<Board>
    {
        IBoardRepository BoardRepository { get; set; }

        Task<IEnumerable<Board>> GetAllBoardsByUserId(long userId);

        Task<Board> CreateBoard(Board board);
    }
}
