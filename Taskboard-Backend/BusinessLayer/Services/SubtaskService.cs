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
    }
}
