using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<Note>> GetAllNotesByUserAndBoard(long userId, long boardId)
        {
            return await NoteRepository.GetByBoard(userId, boardId);
        }

        public async Task<Note> CreateNote(Note note)
        {
            note.Created = DateTime.Now;

            await Add(note);

            return note;
        }

        public async Task<Note> EditNote(Note note)
        {
            await Change(note);

            return note;
        }

        public async Task<bool> DeleteNote(Note note)
        {
            await Remove(note);

            return true;
        }
    }
}
