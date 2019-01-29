using System;
using System.Threading.Tasks;
using Common.DataContracts.Activities.Requests.Board;
using Common.Middleware.ExceptionsFilter;
using Gateway.API.Extensions;
using Gateway.BusinessLayer.Interfaces.Activities;
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
        public async Task<IActionResult> GetBoards()
        {
            var boardGetList = new BoardGetListRequest {UserId = this.GetUserId()};

            var boardGetListResult = await _activitiesService.BoardGetList(boardGetList);

            return Ok(boardGetListResult);
        }

        [HttpGet("board/get")]
        public async Task<IActionResult> GetBoard(Guid id)
        {
            var boardGet = new BoardGetRequest {Id = id, UserId = this.GetUserId()};

            var boardGetResult = await _activitiesService.BoardGet(boardGet);

            return Ok(boardGetResult);
        }
    }
}
