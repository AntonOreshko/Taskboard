using System.Threading.Tasks;
using Common.DataContracts.Activities.Requests.Board;
using Common.DataContracts.Activities.Responses.Board;
using Gateway.BusinessLayer.Interfaces.Activities;
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

        public ActivitiesService
        (
            IRequestClient<BoardCreateRequest, BoardCreateResponse> boardCreateRequest,
            IRequestClient<BoardUpdateRequest, BoardUpdateResponse> boardUpdateRequest,
            IRequestClient<BoardDeleteRequest, BoardDeleteResponse> boardDeleteRequest,
            IRequestClient<BoardGetListRequest, BoardGetListResponse> boardGetListRequest,
            IRequestClient<BoardGetRequest, BoardGetResponse> boardGetRequest
        )
        {
            _boardCreateRequest = boardCreateRequest;
            _boardUpdateRequest = boardUpdateRequest;
            _boardDeleteRequest = boardDeleteRequest;
            _boardGetListRequest = boardGetListRequest;
            _boardGetRequest = boardGetRequest;
        }

        public async Task<BoardCreateResponse> BoardCreate(BoardCreateRequest boardCreateRequest)
        {
            return await _boardCreateRequest.Request(boardCreateRequest);
        }

        public async Task<BoardUpdateResponse> BoardUpdate(BoardUpdateRequest boardUpdateRequest)
        {
            return await _boardUpdateRequest.Request(boardUpdateRequest);
        }

        public async Task<BoardDeleteResponse> BoardDelete(BoardDeleteRequest boardDeleteRequest)
        {
            return await _boardDeleteRequest.Request(boardDeleteRequest);
        }

        public async Task<BoardGetListResponse> BoardGetList(BoardGetListRequest boardGetListRequest)
        {
            return await _boardGetListRequest.Request(boardGetListRequest);
        }

        public async Task<BoardGetResponse> BoardGet(BoardGetRequest boardGetRequest)
        {
            return await _boardGetRequest.Request(boardGetRequest);
        }
    }
}
