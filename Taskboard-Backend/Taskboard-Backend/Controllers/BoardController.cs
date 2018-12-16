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

        [HttpPost("add")]
        public async Task<IActionResult> AddBoard(BoardCreateDto boardCreateDto)
        {
            var userId = this.GetUserId();

            var board = _mapper.Map<Board>(boardCreateDto);
            board.CreatedById = userId;

            await _boardService.CreateBoard(board);

            var boardReturnDto = _mapper.Map<BoardReturnDto>(board);

            return Ok(boardReturnDto);
        }

        [HttpPut("edit")]
        public async Task<IActionResult> EditBoard(BoardEditDto boardEditDto)
        {
            var board = await _boardService.Get(boardEditDto.Id);

            if (board.CreatedById != this.GetUserId())
            {
                return Unauthorized();
            }

            board.Name = boardEditDto.Name;
            board.Description = boardEditDto.Description;

            board = await _boardService.EditBoard(board);

            var boardReturnDto = _mapper.Map<BoardReturnDto>(board);

            return Ok(boardReturnDto);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteBoard(long id)
        {
            var board = await _boardService.Get(id);

            if (board.CreatedById != this.GetUserId())
            {
                return Unauthorized();
            }

            var result = await _boardService.DeleteBoard(board);

            return Ok(result);
        }
    }
}