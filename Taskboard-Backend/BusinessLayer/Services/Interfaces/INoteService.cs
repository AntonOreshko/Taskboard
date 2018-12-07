using DomainModels.Models;
using RepositoryLayer.Repository;

namespace BusinessLayer.Services.Interfaces
{
    public interface INoteService : IDatabaseItemService<Note>
    {
        INoteRepository NoteRepository { get; set; }
    }
}
