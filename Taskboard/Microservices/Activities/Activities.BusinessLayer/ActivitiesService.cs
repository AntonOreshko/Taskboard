using System;
using System.Threading.Tasks;
using Activities.BusinessLayer.Interfaces;
using Activities.DomainModels.Interfaces;
using Activities.Repository.Interfaces;
using Common.DataContracts.Activities.Requests.Board;
using Common.DataContracts.Activities.Responses.Board;
using Common.Errors;

namespace Activities.BusinessLayer
{
    public class ActivitiesService: IActivitiesService
    {
        private readonly IBoardRepository _boardRepository;

        private readonly IBoardCreator _boardCreator;

        public ActivitiesService(
            IBoardRepository boardRepository,
            IBoardCreator boardCreator)
        {
            _boardRepository = boardRepository;
            _boardCreator = boardCreator;
        }

        public async Task<BoardCreateResponse> BoardCreate(BoardCreateRequest boardCreateRequest)
        {
            var board = _boardCreator.CreateBoard(boardCreateRequest);

            await _boardRepository.InsertAsync(board);

            var boardCreated = _boardCreator.CreateBoardCreated(board);
            boardCreated.Succeeded();

            return boardCreated;
        }

        public async Task<BoardUpdateResponse> BoardUpdate(BoardUpdateRequest boardUpdateRequest)
        {
            BoardUpdateResponse boardUpdated;

            var board = await _boardRepository.GetAsync(boardUpdateRequest.Id);
            if (board.CreatedById != boardUpdateRequest.UserId)
            {
                boardUpdated = new BoardUpdateResponse { Data = null };
                boardUpdated.Failed(ErrorManager.GetById(33));

                return boardUpdated;
            }

            _boardCreator.UpdateBoard(board, boardUpdateRequest);

            await _boardRepository.UpdateAsync(board);

            boardUpdated = _boardCreator.CreateBoardUpdated(board);
            boardUpdated.Succeeded();

            return boardUpdated;
        }

        public async Task<BoardDeleteResponse> BoardDelete(BoardDeleteRequest boardDeleteRequest)
        {
            BoardDeleteResponse boardDeleted;

            var board = await _boardRepository.GetAsync(boardDeleteRequest.Id);
            if (board.CreatedById != boardDeleteRequest.UserId)
            {
                boardDeleted = new BoardDeleteResponse { Id = Guid.Empty };
                boardDeleted.Failed(ErrorManager.GetById(33));

                return boardDeleted;
            }

            await _boardRepository.RemoveAsync(boardDeleteRequest.Id);

            boardDeleted = _boardCreator.CreateBoardDeleted(boardDeleteRequest.Id);
            boardDeleted.Succeeded();

            return boardDeleted;
        }

        public async Task<BoardGetListResponse> BoardGetList(BoardGetListRequest boardGetListRequest)
        {
            BoardGetListResponse boardGetList;

            var boards = await _boardRepository.GetByUserId(boardGetListRequest.UserId);

            boardGetList = _boardCreator.CreateBoardGetListResponse(boards);
            boardGetList.Succeeded();

            return boardGetList;
        }

        public async Task<BoardGetResponse> BoardGet(BoardGetRequest boardGetRequest)
        {
            BoardGetResponse boardGetResponse;

            var board = await _boardRepository.GetAsync(boardGetRequest.Id);
            if (board.CreatedById != boardGetRequest.UserId)
            {
                boardGetResponse = new BoardGetResponse { Data = null };
                boardGetResponse.Failed(ErrorManager.GetById(33));

                return boardGetResponse;
            }

            boardGetResponse = _boardCreator.CreateBoardGetResponse(board);
            boardGetResponse.Succeeded();

            return boardGetResponse;
        }
    }
}
