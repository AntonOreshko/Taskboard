using System.Threading.Tasks;
using Common.BusinessLayer.Interfaces;
using Common.DataContracts.Activities.Requests.Board;
using Common.DataContracts.Activities.Responses.Board;

namespace Gateway.BusinessLayer.Interfaces.Activities
{
    public interface IActivitiesService: IService
    {
        Task<BoardCreateResponse> BoardCreate(BoardCreateRequest boardCreateRequest);

        Task<BoardUpdateResponse> BoardUpdate(BoardUpdateRequest boardUpdateRequest);

        Task<BoardDeleteResponse> BoardDelete(BoardDeleteRequest boardDeleteRequest);

        Task<BoardGetListResponse> BoardGetList(BoardGetListRequest boardGetListRequest);

        Task<BoardGetResponse> BoardGet(BoardGetRequest boardGetRequest);
    }
}
