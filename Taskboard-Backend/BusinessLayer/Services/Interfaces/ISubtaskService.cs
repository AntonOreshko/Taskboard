using DomainModels.Models;
using RepositoryLayer.Repository;

namespace BusinessLayer.Services.Interfaces
{
    public interface ISubtaskService : IDatabaseItemService<Subtask>
    {
        ISubtaskRepository SubtaskRepository { get; set; }
    }
}
