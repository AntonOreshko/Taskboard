using System.Threading.Tasks;
using Common.DataContracts.Activities.Requests.Board;
using Common.DataContracts.Activities.Requests.Task;
using Common.DataContracts.Activities.Responses.Board;
using Common.DataContracts.Activities.Responses.Task;

namespace Common.BusinessLayer.Interfaces
{
    public interface IActivitiesService: IService
    {
        Task<BoardCreateResponse> BoardCreate(BoardCreateRequest request);

        Task<BoardUpdateResponse> BoardUpdate(BoardUpdateRequest request);

        Task<BoardDeleteResponse> BoardDelete(BoardDeleteRequest request);

        Task<BoardGetListResponse> BoardGetList(BoardGetListRequest request);

        Task<BoardGetResponse> BoardGet(BoardGetRequest request);

        Task<TaskCreateResponse> TaskCreate(TaskCreateRequest request);

        Task<TaskUpdateResponse> TaskUpdate(TaskUpdateRequest request);

        Task<TaskDeleteResponse> TaskDelete(TaskDeleteRequest request);

        Task<TaskGetListResponse> TaskGetList(TaskGetListRequest request);

        Task<TaskGetResponse> TaskGet(TaskGetRequest request);

        Task<TaskCompleteResponse> TaskComplete(TaskCompleteRequest request);
    }
}
