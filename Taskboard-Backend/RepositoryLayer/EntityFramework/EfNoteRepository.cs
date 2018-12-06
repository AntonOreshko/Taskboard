using DomainModels.Models;
using RepositoryLayer.EntityFramework.Context;
using RepositoryLayer.Repository;

namespace RepositoryLayer.EntityFramework
{
    public class EfNoteRepository : EfRepository<Note>, INoteRepository
    {
        public EfNoteRepository(TaskboardContext context) : base(context)
        {

        }
    }
}