using DomainModels.Models;
using RepositoryLayer.EntityFramework.Context;
using RepositoryLayer.Repository;

namespace RepositoryLayer.EntityFramework
{
    public class EfTaskRepository : EfRepository<Task>, ITaskRepository
    {
        public EfTaskRepository(TaskboardContext context) : base(context)
        {

        }
    }
}
