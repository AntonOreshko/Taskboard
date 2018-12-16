using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using WebApi.Extensions;
using Task = DomainModels.Models.Task;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        private readonly IMapper _mapper;

        public TaskController(ITaskService taskService, IMapper mapper)
        {
            _taskService = taskService;
            _mapper = mapper;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetTasks(long boardId)
        {
            var userId = this.GetUserId();

            var tasks = await _taskService.GetAllTasksByUserAndBoard(userId, boardId);

            var tasksToReturn = _mapper.Map<IEnumerable<TaskReturnDto>>(tasks);

            return Ok(tasksToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTask(long id)
        {
            var task = await _taskService.Get(id);

            if (task.CreatedById != this.GetUserId())
            {
                return Unauthorized();
            }

            var taskReturnDto = _mapper.Map<TaskReturnDto>(task);

            return Ok(taskReturnDto);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddTask(TaskCreateDto taskCreateDto)
        {
            var userId = this.GetUserId();

            var task = _mapper.Map<Task>(taskCreateDto);
            task.CreatedById = userId;

            await _taskService.CreateTask(task);

            var taskReturnDto = _mapper.Map<TaskReturnDto>(task);

            return Ok(taskReturnDto);
        }

        [HttpPut("edit")]
        public async Task<IActionResult> EditTask(TaskEditDto taskEditDto)
        {
            var task = await _taskService.Get(taskEditDto.Id);

            if (task.CreatedById != this.GetUserId())
            {
                return Unauthorized();
            }

            task.Name = taskEditDto.Name;
            task.Description = taskEditDto.Description;

            task = await _taskService.EditTask(task);

            var taskReturnDto = _mapper.Map<TaskReturnDto>(task);

            return Ok(taskReturnDto);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteTask(long id)
        {
            var task = await _taskService.Get(id);

            if (task.CreatedById != this.GetUserId())
            {
                return Unauthorized();
            }

            var result = await _taskService.DeleteTask(task);

            return Ok(result);
        }
    }
}