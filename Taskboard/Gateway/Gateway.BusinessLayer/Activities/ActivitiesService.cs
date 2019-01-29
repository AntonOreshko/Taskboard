using System.Threading.Tasks;
using Common.BusinessLayer.Interfaces;
using Common.DataContracts.Activities.Requests.Board;
using Common.DataContracts.Activities.Requests.Task;
using Common.DataContracts.Activities.Responses.Board;
using Common.DataContracts.Activities.Responses.Task;
using MassTransit;

namespace Gateway.BusinessLayer.Activities
{
    public class ActivitiesService: IActivitiesService
    {
        private readonly IRequestClient<BoardCreateRequest, BoardCreateResponse> _boardCreateRequest;

        private readonly IRequestClient<BoardUpdateRequest, BoardUpdateResponse> _boardUpdateRequest;

        private readonly IRequestClient<BoardDeleteRequest, BoardDeleteResponse> _boardDeleteRequest;

        private readonly IRequestClient<BoardGetListRequest, BoardGetListResponse> _boardGetListRequest;

        private readonly IRequestClient<BoardGetRequest, BoardGetResponse> _boardGetRequest;

        private readonly IRequestClient<TaskCreateRequest, TaskCreateResponse> _taskCreateRequest;

        private readonly IRequestClient<TaskUpdateRequest, TaskUpdateResponse> _taskUpdateRequest;

        private readonly IRequestClient<TaskDeleteRequest, TaskDeleteResponse> _taskDeleteRequest;

        private readonly IRequestClient<TaskGetListRequest, TaskGetListResponse> _taskGetListRequest;

        private readonly IRequestClient<TaskGetRequest, TaskGetResponse> _taskGetRequest;

        private readonly IRequestClient<TaskCompleteRequest, TaskCompleteResponse> _taskCompleteRequest;

        public ActivitiesService
        (
            IRequestClient<BoardCreateRequest, BoardCreateResponse> boardCreateRequest,
            IRequestClient<BoardUpdateRequest, BoardUpdateResponse> boardUpdateRequest,
            IRequestClient<BoardDeleteRequest, BoardDeleteResponse> boardDeleteRequest,
            IRequestClient<BoardGetListRequest, BoardGetListResponse> boardGetListRequest,
            IRequestClient<BoardGetRequest, BoardGetResponse> boardGetRequest,
            IRequestClient<TaskCreateRequest, TaskCreateResponse> taskCreateRequest,
            IRequestClient<TaskUpdateRequest, TaskUpdateResponse> taskUpdateRequest,
            IRequestClient<TaskDeleteRequest, TaskDeleteResponse> taskDeleteRequest,
            IRequestClient<TaskGetListRequest, TaskGetListResponse> taskGetListRequest,
            IRequestClient<TaskGetRequest, TaskGetResponse> taskGetRequest,
            IRequestClient<TaskCompleteRequest, TaskCompleteResponse> taskCompleteRequest)
        {
            _boardCreateRequest = boardCreateRequest;
            _boardUpdateRequest = boardUpdateRequest;
            _boardDeleteRequest = boardDeleteRequest;
            _boardGetListRequest = boardGetListRequest;
            _boardGetRequest = boardGetRequest;
            _taskCreateRequest = taskCreateRequest;
            _taskUpdateRequest = taskUpdateRequest;
            _taskDeleteRequest = taskDeleteRequest;
            _taskGetListRequest = taskGetListRequest;
            _taskGetRequest = taskGetRequest;
            _taskCompleteRequest = taskCompleteRequest;
        }

        public async Task<BoardCreateResponse> BoardCreate(BoardCreateRequest request)
        {
            return await _boardCreateRequest.Request(request);
        }

        public async Task<BoardUpdateResponse> BoardUpdate(BoardUpdateRequest request)
        {
            return await _boardUpdateRequest.Request(request);
        }

        public async Task<BoardDeleteResponse> BoardDelete(BoardDeleteRequest request)
        {
            return await _boardDeleteRequest.Request(request);
        }

        public async Task<BoardGetListResponse> BoardGetList(BoardGetListRequest request)
        {
            return await _boardGetListRequest.Request(request);
        }

        public async Task<BoardGetResponse> BoardGet(BoardGetRequest request)
        {
            return await _boardGetRequest.Request(request);
        }

        public async Task<TaskCreateResponse> TaskCreate(TaskCreateRequest request)
        {
            return await _taskCreateRequest.Request(request);
        }

        public async Task<TaskUpdateResponse> TaskUpdate(TaskUpdateRequest request)
        {
            return await _taskUpdateRequest.Request(request);
        }

        public async Task<TaskDeleteResponse> TaskDelete(TaskDeleteRequest request)
        {
            return await _taskDeleteRequest.Request(request);
        }

        public async Task<TaskGetListResponse> TaskGetList(TaskGetListRequest request)
        {
            return await _taskGetListRequest.Request(request);
        }

        public async Task<TaskGetResponse> TaskGet(TaskGetRequest request)
        {
            return await _taskGetRequest.Request(request);
        }

        public async Task<TaskCompleteResponse> TaskComplete(TaskCompleteRequest request)
        {
            return await _taskCompleteRequest.Request(request);
        }
    }
}
