using BusinessLayer.Services.Interfaces;
using DomainModels.Models;
using RepositoryLayer.Repository;

namespace BusinessLayer.Services
{
    public class NoteService : DatabaseItemService<Note>, INoteService
    {
        public INoteRepository NoteRepository { get; set; }

        public NoteService(IRepository<Note> repo, INoteRepository customRepo): base(repo)
        {
            NoteRepository = customRepo;
        }
    }
}
