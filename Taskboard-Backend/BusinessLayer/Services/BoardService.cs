using BusinessLayer.Services.Interfaces;
using DomainModels.Models;
using RepositoryLayer.Repository;

namespace BusinessLayer.Services
{
    public class BoardService : DatabaseItemService<Board>, IBoardService
    {
        public IBoardRepository BoardRepository { get; set; }

        public BoardService(IRepository<Board> repo, IBoardRepository customRepo) : base(repo)
        {
            BoardRepository = customRepo;
        }
    }
}
