using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Services.Interfaces;
using RepositoryLayer.Repository;
using Task = DomainModels.Models.Task;

namespace BusinessLayer.Services
{
    public class TaskService : DatabaseItemService<Task>, ITaskService
    {
        public ITaskRepository TaskRepository { get; set; }

        public TaskService(IRepository<Task> repo, ITaskRepository customRepo): base(repo)
        {
            TaskRepository = customRepo;
        }

        public async Task<IEnumerable<Task>> GetAllTasksByUserAndBoard(long userId, long boardId)
        {
            return await TaskRepository.GetByBoard(userId, boardId);
        }

        public async Task<Task> CreateTask(Task task)
        {
            task.Created = DateTime.Now;

            await Add(task);

            return task;
        }

        public async Task<Task> EditTask(Task task)
        {
            await Change(task);

            return task;
        }

        public async Task<bool> DeleteTask(Task task)
        {
            await Remove(task);

            return true;
        }
    }
}
