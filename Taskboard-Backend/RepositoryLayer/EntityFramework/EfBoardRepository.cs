using System.Threading.Tasks;
using DomainModels.Models;
using RepositoryLayer.EntityFramework.Context;
using RepositoryLayer.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace RepositoryLayer.EntityFramework
{
    public class EfBoardRepository : EfRepository<Board>, IBoardRepository
    {
        public EfBoardRepository(TaskboardContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Board>> GetByUser(long userId)
        {
            var userBoardIds = Context.UserBoards.Where(ub => ub.UserId == userId).Select(ub => ub.BoardId);

            return await Entities.Where(b => userBoardIds.Contains(b.Id)).ToListAsync();
        }
    }
}
