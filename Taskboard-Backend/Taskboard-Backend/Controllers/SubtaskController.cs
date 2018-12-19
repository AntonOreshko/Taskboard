using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Services.Interfaces;
using DomainModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using WebApi.Extensions;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class SubtaskController : ControllerBase
    {
        private readonly ISubtaskService _subtaskService;

        private readonly IMapper _mapper;

        public SubtaskController(ISubtaskService subtaskService, IMapper mapper)
        {
            _subtaskService = subtaskService;
            _mapper = mapper;
        }

        [HttpGet("list/{taskId}")]
        public async Task<IActionResult> GetSubtasks(long taskId)
        {
            var userId = this.GetUserId();

            var subtasks = await _subtaskService.GetAllSubtasksByUserAndTask(userId, taskId);

            var subtasksToReturn = _mapper.Map<IEnumerable<SubtaskReturnDto>>(subtasks);

            return Ok(subtasksToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubtask(long id)
        {
            var subtask = await _subtaskService.Get(id);

            if (subtask.CreatedById != this.GetUserId())
            {
                return Unauthorized();
            }

            var subtaskReturnDto = _mapper.Map<SubtaskReturnDto>(subtask);

            return Ok(subtaskReturnDto);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddSubtask(SubtaskCreateDto subtaskCreateDto)
        {
            var userId = this.GetUserId();

            var subtask = _mapper.Map<Subtask>(subtaskCreateDto);
            subtask.CreatedById = userId;

            await _subtaskService.CreateSubtask(subtask);

            var subtaskReturnDto = _mapper.Map<SubtaskReturnDto>(subtask);

            return Ok(subtaskReturnDto);
        }

        [HttpPut("edit")]
        public async Task<IActionResult> EditSubtask(SubtaskEditDto subtaskEditDto)
        {
            var subtask = await _subtaskService.Get(subtaskEditDto.Id);

            if (subtask.CreatedById != this.GetUserId())
            {
                return Unauthorized();
            }

            subtask.Name = subtaskEditDto.Name;
            subtask.Description = subtaskEditDto.Description;

            subtask = await _subtaskService.EditSubtask(subtask);

            var subtaskReturnDto = _mapper.Map<SubtaskReturnDto>(subtask);

            return Ok(subtaskReturnDto);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteSubtask(long id)
        {
            var subtask = await _subtaskService.Get(id);

            if (subtask.CreatedById != this.GetUserId())
            {
                return Unauthorized();
            }

            var result = await _subtaskService.DeleteSubtask(subtask);

            return Ok(result);
        }
    }
}