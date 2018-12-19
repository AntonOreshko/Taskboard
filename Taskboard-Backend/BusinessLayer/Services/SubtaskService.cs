using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Services.Interfaces;
using DomainModels.Models;
using RepositoryLayer.Repository;

namespace BusinessLayer.Services
{
    public class SubtaskService : DatabaseItemService<Subtask>, ISubtaskService
    {
        public ISubtaskRepository SubtaskRepository { get; set; }

        public SubtaskService(IRepository<Subtask> repo, ISubtaskRepository customRepo) : base(repo)
        {
            SubtaskRepository = customRepo;
        }

        public async Task<IEnumerable<Subtask>> GetAllSubtasksByUserAndTask(long userId, long taskId)
        {
            return await SubtaskRepository.GetByTask(userId, taskId);
        }

        public async Task<Subtask> CreateSubtask(Subtask subtask)
        {
            subtask.Created = DateTime.Now;

            await Add(subtask);

            return subtask;
        }

        public async Task<Subtask> EditSubtask(Subtask subtask)
        {
            await Change(subtask);

            return subtask;
        }

        public async Task<bool> DeleteSubtask(Subtask subtask)
        {
            await Remove(subtask);

            return true;
        }
    }
}
