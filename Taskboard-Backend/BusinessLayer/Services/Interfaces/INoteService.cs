using System.Collections.Generic;
using System.Threading.Tasks;
using DomainModels.Models;
using RepositoryLayer.Repository;

namespace BusinessLayer.Services.Interfaces
{
    public interface INoteService : IDatabaseItemService<Note>
    {
        INoteRepository NoteRepository { get; set; }

        Task<IEnumerable<Note>> GetAllNotesByUserAndBoard(long userId, long boardId);

        Task<Note> CreateNote(Note note);

        Task<Note> EditNote(Note note);

        Task<bool> DeleteNote(Note note);
    }
}
