using DomainModels.Models;
using RepositoryLayer.Repository;

namespace BusinessLayer.Services.Interfaces
{
    public interface ITaskService : IDatabaseItemService<Task>
    {
        ITaskRepository TaskRepository { get; set; }
    }
}
