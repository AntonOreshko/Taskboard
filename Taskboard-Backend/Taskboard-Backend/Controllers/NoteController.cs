using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Services.Interfaces;
using DomainModels.Models;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using WebApi.Extensions;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;

        private readonly IMapper _mapper;

        public NoteController(INoteService noteService, IMapper mapper)
        {
            _noteService = noteService;
            _mapper = mapper;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetNotes(long boardId)
        {
            var userId = this.GetUserId();

            var notes = await _noteService.GetAllNotesByUserAndBoard(userId, boardId);

            var notesToReturn = _mapper.Map<IEnumerable<NoteReturnDto>>(notes);

            return Ok(notesToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNote(long id)
        {
            var note = await _noteService.Get(id);

            if (note.CreatedById != this.GetUserId())
            {
                return Unauthorized();
            }

            var noteReturnDto = _mapper.Map<NoteReturnDto>(note);

            return Ok(noteReturnDto);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddNote(NoteCreateDto noteCreateDto)
        {
            var userId = this.GetUserId();

            var note = _mapper.Map<Note>(noteCreateDto);
            note.CreatedById = userId;

            await _noteService.CreateNote(note);

            var noteReturnDto = _mapper.Map<NoteReturnDto>(note);

            return Ok(noteReturnDto);
        }

        [HttpPut("edit")]
        public async Task<IActionResult> EditNote(NoteEditDto noteEditDto)
        {
            var note = await _noteService.Get(noteEditDto.Id);

            if (note.CreatedById != this.GetUserId())
            {
                return Unauthorized();
            }

            note.Name = noteEditDto.Name;
            note.Description = noteEditDto.Description;

            note = await _noteService.EditNote(note);

            var noteReturnDto = _mapper.Map<NoteReturnDto>(note);

            return Ok(noteReturnDto);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteNote(long id)
        {
            var note = await _noteService.Get(id);

            if (note.CreatedById != this.GetUserId())
            {
                return Unauthorized();
            }

            var result = await _noteService.DeleteNote(note);

            return Ok(result);
        }
    }
}