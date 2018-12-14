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
    [ApiController]
    [Authorize]
    public class BoardController : ControllerBase
    {
        private readonly IBoardService _boardService;

        private readonly IMapper _mapper;

        public BoardController(IBoardService boardService, IMapper mapper)
        {
            _boardService = boardService;
            _mapper = mapper;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetBoards()
        {
            var userId = this.GetUserId();

            var boards = await _boardService.GetAllBoardsByUserId(userId);

            var boardsToReturn = _mapper.Map<IEnumerable<BoardReturnDto>>(boards);

            return Ok(boardsToReturn);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddBoard(BoardCreateDto boardCreateDto)
        {
            var userId = this.GetUserId();

            var board = new Board
            {
                CreatedById = userId,
                Name = boardCreateDto.Name,
                Description = boardCreateDto.Description
            };

            await _boardService.CreateBoard(board);

            var boardReturnDto = _mapper.Map<BoardReturnDto>(board);

            return Ok(boardReturnDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBoard(long id)
        {
            var board = await _boardService.Get(id);

            if (board.CreatedById != this.GetUserId())
            {
                return Unauthorized();
            }

            var boardReturnDto = _mapper.Map<BoardReturnDto>(board);

            return Ok(boardReturnDto);
        }
        [HttpPut("edit/{id}")]
        public async Task<IActionResult> UpdateBoard(long id, BoardCreateDto boardCreateDto)
        {
            var board = await _boardService.Get(id);

            if (board.CreatedById != this.GetUserId())
            {
                return Unauthorized();
            }

            board.Name = boardCreateDto.Name;
            board.Description = boardCreateDto.Description;

            board = await _boardService.EditBoard(board);

            var boardReturnDto = _mapper.Map<BoardReturnDto>(board);

            return Ok(boardReturnDto);
        }

    }
}