using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Activities.DomainModels.Interfaces;
using Activities.Repository.Interfaces;
using Common.BusinessLayer.Interfaces;
using Common.DataContracts.Activities.Requests.Board;
using Common.DataContracts.Activities.Requests.Task;
using Common.DataContracts.Activities.Responses.Board;
using Common.DataContracts.Activities.Responses.Task;
using Common.Errors;
using Task = Activities.DomainModels.Models.Task;

namespace Activities.BusinessLayer
{
    public class ActivitiesService: IActivitiesService
    {
        private readonly IBoardRepository _boardRepository;

        private readonly IBoardCreator _boardCreator;

        private readonly ITaskCreator _taskCreator;

        private readonly IErrorService _errorService;

        public ActivitiesService(
            IBoardRepository boardRepository,
            IBoardCreator boardCreator,
            ITaskCreator taskCreator,
            IErrorService errorService)
        {
            _boardRepository = boardRepository;
            _boardCreator = boardCreator;
            _taskCreator = taskCreator;
            _errorService = errorService;
        }

        public async Task<BoardCreateResponse> BoardCreate(BoardCreateRequest request)
        {
            var board = _boardCreator.CreateBoard(request);

            await _boardRepository.InsertAsync(board);

            var response = _boardCreator.CreateBoardCreateResponse(board);
            response.Succeeded();

            return response;
        }

        public async Task<BoardUpdateResponse> BoardUpdate(BoardUpdateRequest request)
        {
            BoardUpdateResponse response;

            var board = await _boardRepository.GetAsync(request.Id);

            if (board == null)
            {
                response = new BoardUpdateResponse { Data = null };
                response.Failed(_errorService.GetError(ErrorType.ItemNotFound));

                return response;
            }

            if (board.CreatedById != request.UserId)
            {
                response = new BoardUpdateResponse { Data = null };
                response.Failed(_errorService.GetError(ErrorType.AccessDenied));

                return response;
            }

            _boardCreator.UpdateBoard(board, request);

            await _boardRepository.UpdateAsync(board);

            response = _boardCreator.CreateBoardUpdateResponse(board);
            response.Succeeded();

            return response;
        }

        public async Task<BoardDeleteResponse> BoardDelete(BoardDeleteRequest request)
        {
            BoardDeleteResponse response;

            var board = await _boardRepository.GetAsync(request.Id);

            if (board == null)
            {
                response = new BoardDeleteResponse { Id = Guid.Empty };
                response.Failed(_errorService.GetError(ErrorType.ItemNotFound));

                return response;
            }

            if (board.CreatedById != request.UserId)
            {
                response = new BoardDeleteResponse { Id = Guid.Empty };
                response.Failed(_errorService.GetError(ErrorType.AccessDenied));

                return response;
            }

            await _boardRepository.RemoveAsync(request.Id);

            response = _boardCreator.CreateBoardDeleteResponse(request.Id);
            response.Succeeded();

            return response;
        }

        public async Task<BoardGetListResponse> BoardGetList(BoardGetListRequest request)
        {
            BoardGetListResponse response;

            var boards = await _boardRepository.GetByUserId(request.UserId);

            response = _boardCreator.CreateBoardGetListResponse(boards);
            response.Succeeded();

            return response;
        }

        public async Task<BoardGetResponse> BoardGet(BoardGetRequest request)
        {
            BoardGetResponse response;

            var board = await _boardRepository.GetAsync(request.Id);

            if (board == null)
            {
                response = new BoardGetResponse { Data = null };
                response.Failed(_errorService.GetError(ErrorType.ItemNotFound));

                return response;
            }

            if (board.CreatedById != request.UserId)
            {
                response = new BoardGetResponse { Data = null };
                response.Failed(_errorService.GetError(ErrorType.AccessDenied));

                return response;
            }

            response = _boardCreator.CreateBoardGetResponse(board);
            response.Succeeded();

            return response;
        }

        public async Task<TaskCreateResponse> TaskCreate(TaskCreateRequest request)
        {
            TaskCreateResponse response;

            var board = await _boardRepository.GetAsync(request.BoardId);

            if (board == null)
            {
                response = new TaskCreateResponse { Data = null };
                response.Failed(_errorService.GetError(ErrorType.ItemNotFound));

                return response;
            }

            if (board.CreatedById != request.UserId)
            {
                response = new TaskCreateResponse { Data = null };
                response.Failed(_errorService.GetError(ErrorType.AccessDenied));

                return response;
            }

            if (board.Tasks == null) board.Tasks = new List<Task>();

            var task = _taskCreator.CreateTask(request);

            await _boardRepository.TaskCreate(request.BoardId, task);

            response = _taskCreator.CreateTaskCreateResponse(task);
            response.Succeeded();

            return response;
        }

        public async Task<TaskUpdateResponse> TaskUpdate(TaskUpdateRequest request)
        {
            TaskUpdateResponse response;

            var board = await _boardRepository.GetAsync(request.BoardId);

            if (board == null)
            {
                response = new TaskUpdateResponse { Data = null };
                response.Failed(_errorService.GetError(ErrorType.ItemNotFound));

                return response;
            }

            if (board.CreatedById != request.UserId)
            {
                response = new TaskUpdateResponse { Data = null };
                response.Failed(_errorService.GetError(ErrorType.AccessDenied));

                return response;
            }

            var task = board.Tasks.Single(t => t.Id == request.Id);
            if (task == null)
            {
                response = new TaskUpdateResponse { Data = null };
                response.Failed(_errorService.GetError(ErrorType.ItemNotFound));

                return response;
            }

            _taskCreator.UpdateTask(task, request);

            await _boardRepository.UpdateAsync(board);

            response = _taskCreator.CreateTaskUpdateResponse(task);
            response.Succeeded();

            return response;
        }

        public async Task<TaskDeleteResponse> TaskDelete(TaskDeleteRequest request)
        {
            TaskDeleteResponse response;

            var board = await _boardRepository.GetAsync(request.BoardId);

            if (board == null)
            {
                response = new TaskDeleteResponse { Id = Guid.Empty };
                response.Failed(_errorService.GetError(ErrorType.ItemNotFound));

                return response;
            }

            if (board.CreatedById != request.UserId)
            {
                response = new TaskDeleteResponse { Id = Guid.Empty };
                response.Failed(_errorService.GetError(ErrorType.AccessDenied));

                return response;
            }

            var task = board.Tasks.Single(t => t.Id == request.Id);
            if (task == null)
            {
                response = new TaskDeleteResponse { Id = Guid.Empty };
                response.Failed(_errorService.GetError(ErrorType.ItemNotFound));

                return response;
            }

            board.Tasks.Remove(task);

            await _boardRepository.UpdateAsync(board);

            response = _taskCreator.CreateTaskDeleteResponse(request.Id);
            response.Succeeded();

            return response;
        }

        public async Task<TaskGetListResponse> TaskGetList(TaskGetListRequest request)
        {
            TaskGetListResponse response;

            var board = await _boardRepository.GetAsync(request.BoardId);

            if (board == null)
            {
                response = new TaskGetListResponse { Data = null };
                response.Failed(_errorService.GetError(ErrorType.ItemNotFound));

                return response;
            }

            if (board.CreatedById != request.UserId)
            {
                response = new TaskGetListResponse { Data = null };
                response.Failed(_errorService.GetError(ErrorType.AccessDenied));

                return response;
            }

            if (board.Tasks == null) board.Tasks = new List<Task>();

            response = _taskCreator.CreateTaskGetListResponse(board.Tasks);
            response.Succeeded();

            return response;
        }

        public async Task<TaskGetResponse> TaskGet(TaskGetRequest request)
        {
            TaskGetResponse response;

            var board = await _boardRepository.GetAsync(request.BoardId);

            if (board == null)
            {
                response = new TaskGetResponse { Data = null };
                response.Failed(_errorService.GetError(ErrorType.ItemNotFound));

                return response;
            }

            if (board.CreatedById != request.UserId)
            {
                response = new TaskGetResponse { Data = null };
                response.Failed(_errorService.GetError(ErrorType.AccessDenied));

                return response;
            }

            var task = board.Tasks.Single(t => t.Id == request.Id);
            if (task == null)
            {
                response = new TaskGetResponse { Data = null };
                response.Failed(_errorService.GetError(ErrorType.ItemNotFound));

                return response;
            }

            response = _taskCreator.CreateTaskGetResponse(task);
            response.Succeeded();

            return response;
        }

        public async Task<TaskCompleteResponse> TaskComplete(TaskCompleteRequest request)
        {
            TaskCompleteResponse response;

            var board = await _boardRepository.GetAsync(request.BoardId);

            if (board != null)
            {
                response = new TaskCompleteResponse { Data = null };
                response.Failed(_errorService.GetError(ErrorType.ItemNotFound));

                return response;
            }

            if (board.CreatedById != request.UserId)
            {
                response = new TaskCompleteResponse { Data = null };
                response.Failed(_errorService.GetError(ErrorType.AccessDenied));

                return response;
            }

            var task = board.Tasks.Single(t => t.Id == request.Id);
            if (task == null)
            {
                response = new TaskCompleteResponse { Data = null };
                response.Failed(_errorService.GetError(ErrorType.ItemNotFound));

                return response;
            }

            task.Completed = true;

            await _boardRepository.UpdateAsync(board);

            response = _taskCreator.CreateTaskCompleteResponse(task);
            response.Succeeded();

            return response;
        }
    }
}
