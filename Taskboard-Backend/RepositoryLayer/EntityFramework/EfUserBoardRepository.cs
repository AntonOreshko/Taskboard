using DomainModels.Models;
using RepositoryLayer.EntityFramework.Context;
using RepositoryLayer.Repository;

namespace RepositoryLayer.EntityFramework
{
    public class EfUserBoardRepository : EfRepository<UserBoard>, IUserBoardRepository
    {
        public EfUserBoardRepository(TaskboardContext context) : base(context)
        {
        }
    }
}
