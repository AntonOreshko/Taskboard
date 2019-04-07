using System.Collections.Generic;
using Common.DataContracts.Activities.Dto;

namespace Common.DataContracts.Activities.Responses.Task
{
    public class TaskGetListResponse: Response
    {
        public IEnumerable<TaskDto> Data { get; set; }
    }
}
