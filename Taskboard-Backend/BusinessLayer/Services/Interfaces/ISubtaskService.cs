using System.Collections.Generic;
using System.Threading.Tasks;
using DomainModels.Models;
using RepositoryLayer.Repository;

namespace BusinessLayer.Services.Interfaces
{
    public interface ISubtaskService : IDatabaseItemService<Subtask>
    {
        ISubtaskRepository SubtaskRepository { get; set; }

        Task<IEnumerable<Subtask>> GetAllSubtasksByUserAndTask(long userId, long taskId);

        Task<Subtask> CreateSubtask(Subtask subtask);

        Task<Subtask> EditSubtask(Subtask subtask);

        Task<bool> DeleteSubtask(Subtask subtask);
    }
}
