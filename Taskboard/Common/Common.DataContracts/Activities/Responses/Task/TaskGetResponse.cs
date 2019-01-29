using Common.DataContracts.Activities.Dto;

namespace Common.DataContracts.Activities.Responses.Task
{
    public class TaskGetResponse: Response
    {
        public TaskDto Data { get; set; }
    }
}
