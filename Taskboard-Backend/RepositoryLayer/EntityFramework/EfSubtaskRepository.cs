using DomainModels.Models;
using RepositoryLayer.EntityFramework.Context;
using RepositoryLayer.Repository;

namespace RepositoryLayer.EntityFramework
{
    public class EfSubtaskRepository : EfRepository<Subtask>, ISubtaskRepository
    {
        public EfSubtaskRepository(TaskboardContext context) : base(context)
        {

        }
    }
}
