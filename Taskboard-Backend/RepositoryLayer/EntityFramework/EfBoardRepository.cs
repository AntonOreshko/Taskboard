using DomainModels.Models;
using RepositoryLayer.EntityFramework.Context;
using RepositoryLayer.Repository;

namespace RepositoryLayer.EntityFramework
{
    public class EfBoardRepository : EfRepository<Board>, IBoardRepository
    {
        public EfBoardRepository(TaskboardContext context) : base(context)
        {

        }
    }
}
