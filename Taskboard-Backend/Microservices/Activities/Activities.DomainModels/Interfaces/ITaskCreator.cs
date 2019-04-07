using System;
using System.Collections.Generic;
using Activities.DomainModels.Models;
using Common.DataContracts.Activities.Requests.Task;
using Common.DataContracts.Activities.Responses.Task;

namespace Activities.DomainModels.Interfaces
{
    public interface ITaskCreator
    {
        Task CreateTask(TaskCreateRequest taskCreateRequest);

        Task UpdateTask(Task task, TaskUpdateRequest taskUpdateRequest);

        TaskCreateResponse CreateTaskCreateResponse(Task task);

        TaskUpdateResponse CreateTaskUpdateResponse(Task task);

        TaskDeleteResponse CreateTaskDeleteResponse(Guid guid);

        TaskCompleteResponse CreateTaskCompleteResponse(Task task);

        TaskGetListResponse CreateTaskGetListResponse(IEnumerable<Task> tasks);

        TaskGetResponse CreateTaskGetResponse(Task task);
    }
}
