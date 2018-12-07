using BusinessLayer.Services.Interfaces;
using DomainModels.Models;
using RepositoryLayer.Repository;

namespace BusinessLayer.Services
{
    public class TaskService : DatabaseItemService<Task>, ITaskService
    {
        public ITaskRepository TaskRepository { get; set; }

        public TaskService(IRepository<Task> repo, ITaskRepository customRepo): base(repo)
        {
            TaskRepository = customRepo;
        }
    }
}
