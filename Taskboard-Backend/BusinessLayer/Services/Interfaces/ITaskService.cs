using System.Collections.Generic;
using System.Threading.Tasks;
using RepositoryLayer.Repository;

namespace BusinessLayer.Services.Interfaces
{
    public interface ITaskService : IDatabaseItemService<DomainModels.Models.Task>
    {
        ITaskRepository TaskRepository { get; set; }

        Task<IEnumerable<DomainModels.Models.Task>> GetAllTasksByUserAndBoard(long userId, long boardId);

        Task<DomainModels.Models.Task> CreateTask(DomainModels.Models.Task task);

        Task<DomainModels.Models.Task> EditTask(DomainModels.Models.Task task);

        Task<bool> DeleteTask(DomainModels.Models.Task task);
    }
}
