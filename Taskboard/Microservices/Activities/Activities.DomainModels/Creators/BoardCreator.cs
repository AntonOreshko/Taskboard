using System;
using System.Collections.Generic;
using System.Linq;
using Activities.DomainModels.Interfaces;
using Activities.DomainModels.Models;
using Common.DataContracts.Activities.Dto;
using Common.DataContracts.Activities.Requests.Board;
using Common.DataContracts.Activities.Responses.Board;

namespace Activities.DomainModels.Creators
{
    public class BoardCreator: IBoardCreator
    {
        public Board CreateBoard(BoardCreateRequest boardCreateRequest)
        {
            var board = new Board
            {
                Id = Guid.NewGuid(),
                Name = boardCreateRequest.Name,
                Description = boardCreateRequest.Description,
                CreatedById = boardCreateRequest.UserId,
                Created = DateTime.UtcNow,
				Tasks = new List<Task>()
            };

            return board;
        }

        public Board UpdateBoard(Board board, BoardUpdateRequest boardUpdateRequest)
        {
            board.Name = boardUpdateRequest.Name;
            board.Description = boardUpdateRequest.Description;

            return board;
        }

        private BoardDto CreateDto(Board board)
        {
            var boardDto = new BoardDto
            {
                Id = board.Id, Name = board.Name, Description = board.Description, Created = board.Created, CreatedById = board.CreatedById
            };

            return boardDto;
        }

        public BoardCreateResponse CreateBoardCreateResponse(Board board)
        {
            var boardCreated = new BoardCreateResponse
            {
                Data = CreateDto(board)
            };

            return boardCreated;
        }

        public BoardUpdateResponse CreateBoardUpdateResponse(Board board)
        {
            var boardUpdated = new BoardUpdateResponse()
            {
                Data = CreateDto(board)
            };

            return boardUpdated;
        }

        public BoardDeleteResponse CreateBoardDeleteResponse(Guid id)
        {
            var boardDeleted = new BoardDeleteResponse
            {
                Id = id
            };

            return boardDeleted;
        }

        public BoardGetListResponse CreateBoardGetListResponse(IEnumerable<Board> boards)
        {
            var boardsList = new BoardGetListResponse
            {
                Data = boards.Select(CreateDto)
            };

            return boardsList;
        }

        public BoardGetResponse CreateBoardGetResponse(Board board)
        {
            var boardGet = new BoardGetResponse
            {
                Data = CreateDto(board)
            };

            return boardGet;
        }
    }
}
