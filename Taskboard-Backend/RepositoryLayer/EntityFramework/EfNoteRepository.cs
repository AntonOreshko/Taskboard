using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.EntityFramework.Context;
using RepositoryLayer.Repository;

namespace RepositoryLayer.EntityFramework
{
    public class EfNoteRepository : EfRepository<Note>, INoteRepository
    {
        public EfNoteRepository(TaskboardContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Note>> GetByBoard(long userId, long boardId)
        {
            return await Entities.Where(n => n.BoardId == boardId && n.CreatedById == userId).ToListAsync();
        }
    }
}