using System;
using System.Threading.Tasks;
using Common.BusinessLayer.Interfaces;
using Common.DataContracts.Activities.Requests.Board;
using Common.DataContracts.Activities.Requests.Task;
using Common.Middleware.ExceptionsFilter;
using Gateway.API.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExceptionFilter]
    [Authorize]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivitiesService _activitiesService;

        public ActivitiesController(IActivitiesService activitiesService)
        {
            _activitiesService = activitiesService;
        }

        [HttpPost("board/create")]
        public async Task<IActionResult> BoardCreate(BoardCreateRequest boardCreateRequest)
        {
            boardCreateRequest.UserId = this.GetUserId();

            var boardCreateResult = await _activitiesService.BoardCreate(boardCreateRequest);

            return Created(string.Empty, boardCreateResult);
        }

        [HttpPut("board/update")]
        public async Task<IActionResult> BoardUpdate(BoardUpdateRequest boardUpdateRequest)
        {
            boardUpdateRequest.UserId = this.GetUserId();

            var boardUpdatedResult = await _activitiesService.BoardUpdate(boardUpdateRequest);

            return Ok(boardUpdatedResult);
        }

        [HttpDelete("board/delete")]
        public async Task<IActionResult> BoardDelete(Guid id)
        {
            var boardDeleteRequest = new BoardDeleteRequest {Id = id, UserId = this.GetUserId()};

            var boardDeletedResult = await _activitiesService.BoardDelete(boardDeleteRequest);

            return Ok(boardDeletedResult);
        }

        [HttpGet("board/list")]
        public async Task<IActionResult> BoardGetList()
        {
            var boardGetList = new BoardGetListRequest {UserId = this.GetUserId()};

            var boardGetListResult = await _activitiesService.BoardGetList(boardGetList);

            return Ok(boardGetListResult);
        }

        [HttpGet("board/get")]
        public async Task<IActionResult> BoardGet(Guid id)
        {
            var boardGet = new BoardGetRequest {Id = id, UserId = this.GetUserId()};

            var boardGetResult = await _activitiesService.BoardGet(boardGet);

            return Ok(boardGetResult);
        }

        [HttpPost("task/create")]
        public async Task<IActionResult> TaskCreate(TaskCreateRequest taskCreateRequest)
        {
            taskCreateRequest.UserId = this.GetUserId();

            var taskCreateResult = await _activitiesService.TaskCreate(taskCreateRequest);

            return Created(string.Empty, taskCreateResult);
        }

        [HttpPut("task/update")]
        public async Task<IActionResult> TaskUpdate(TaskUpdateRequest request)
        {
            request.UserId = this.GetUserId();

            var response = await _activitiesService.TaskUpdate(request);

            return Ok(response);
        }

        [HttpDelete("task/delete")]
        public async Task<IActionResult> TaskDelete(Guid id, Guid boardId)
        {
            var request = new TaskDeleteRequest
            {
                UserId = this.GetUserId(),
                Id = id,
                BoardId = boardId
            };

            var response = await _activitiesService.TaskDelete(request);

            return Ok(response);
        }

        [HttpGet("task/list")]
        public async Task<IActionResult> TaskGetList(Guid boardId)
        {
            var request = new TaskGetListRequest
            {
                BoardId = boardId,
                UserId = this.GetUserId()
            };

            var response = await _activitiesService.TaskGetList(request);

            return Ok(response);
        }

        [HttpGet("task/get")]
        public async Task<IActionResult> TaskGet(Guid id, Guid boardId)
        {
            var request = new TaskGetRequest
            {
                Id = id,
                BoardId = boardId,
                UserId = this.GetUserId()
            };

            var response = await _activitiesService.TaskGet(request);

            return Ok(response);
        }

        [HttpPost("task/complete")]
        public async Task<IActionResult> TaskComplete(TaskCompleteRequest request)
        {
            request.UserId = this.GetUserId();

            var response = await _activitiesService.TaskComplete(request);

            return Ok(response);
        }
    }
}
