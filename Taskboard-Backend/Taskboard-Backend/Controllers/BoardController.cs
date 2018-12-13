using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Services.Interfaces;
using DomainModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class BoardController : ControllerBase
    {
        private readonly IBoardService _boardService;

        private readonly IMapper _mapper;

        public BoardController(IBoardService boardService, IMapper mapper)
        {
            _boardService = boardService;
            _mapper = mapper;
        }

        [HttpGet("{userId}/list")]
        public async Task<IActionResult> GetBoards(long userId)
        {
            var boards = await _boardService.GetAllBoardsByUserId(userId);

            var boardsToReturn = _mapper.Map<IEnumerable<BoardReturnDto>>(boards);

            return Ok(boardsToReturn);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddBoard(BoardCreateDto boardCreateDto)
        {
            var board = new Board
            {
                CreatedById = boardCreateDto.CreatedById,
                Name = boardCreateDto.Name,
                Description = boardCreateDto.Description
            };

            await _boardService.CreateBoard(board);

            return Ok(board);
        }
    }
}