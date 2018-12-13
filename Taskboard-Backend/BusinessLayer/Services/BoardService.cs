using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Services.Interfaces;
using DomainModels.Models;
using RepositoryLayer.Repository;

namespace BusinessLayer.Services
{
    public class BoardService : DatabaseItemService<Board>, IBoardService
    {
        public IBoardRepository BoardRepository { get; set; }

        public IUserBoardRepository UserBoardRepository { get; set; }

        public BoardService(IRepository<Board> repo, IBoardRepository customRepo): base(repo)
        {
            BoardRepository = customRepo;
        }

        public async Task<IEnumerable<Board>> GetAllBoardsByUserId(long userId)
        {
            return await BoardRepository.GetByUser(userId);
        }

        public async Task<Board> CreateBoard(Board board)
        {
            board.Created = DateTime.Now;

            await Add(board);

            return board;
        }

        public override async System.Threading.Tasks.Task Add(Board board)
        {
            var userBoard = new UserBoard
            {
                UserId = board.CreatedById
            };

            board.UserBoards = new List<UserBoard>
            {
                userBoard
            };

            await BoardRepository.InsertAsync(board);
            await BoardRepository.SaveChangesAsync();
        }
    }
}