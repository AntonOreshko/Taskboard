using System;
using System.Collections.Generic;
using System.Linq;
using Activities.DomainModels.Interfaces;
using Activities.DomainModels.Models;
using Common.DataContracts.Activities.Dto;
using Common.DataContracts.Activities.Requests.Task;
using Common.DataContracts.Activities.Responses.Task;

namespace Activities.DomainModels.Creators
{
    public class TaskCreator: ITaskCreator
    {
        public Task CreateTask(TaskCreateRequest taskCreateRequest)
        {
            var task = new Task
            {
                Id = Guid.NewGuid(),
                Name = taskCreateRequest.Name,
                Description = taskCreateRequest.Description,
                Created = DateTime.UtcNow,
                CreatedById = taskCreateRequest.UserId,
                BoardId = taskCreateRequest.BoardId
            };

            return task;
        }

        public Task UpdateTask(Task task, TaskUpdateRequest taskUpdateRequest)
        {
            task.Name = taskUpdateRequest.Name;
            task.Description = taskUpdateRequest.Description;

            return task;
        }

        private TaskDto CreateDto(Task task)
        {
            var taskDto = new TaskDto
            {
                Id = task.Id, BoardId = task.BoardId, Completed = task.Completed,
                Created = task.Created, CreatedById = task.CreatedById,
                Description = task.Description, Name = task.Name
            };

            return taskDto;
        }

        public TaskCreateResponse CreateTaskCreateResponse(Task task)
        {
            var response = new TaskCreateResponse
            {
                Data = CreateDto(task)
            };

            return response;
        }

        public TaskUpdateResponse CreateTaskUpdateResponse(Task task)
        {
            var response = new TaskUpdateResponse
            {
                Data = CreateDto(task)
            };

            return response;
        }

        public TaskDeleteResponse CreateTaskDeleteResponse(Guid id)
        {
            var response = new TaskDeleteResponse
            {
                Id = id
            };

            return response;
        }

        public TaskCompleteResponse CreateTaskCompleteResponse(Task task)
        {
            var response = new TaskCompleteResponse
            {
                Data = CreateDto(task)
            };

            return response;
        }

        public TaskGetListResponse CreateTaskGetListResponse(IEnumerable<Task> tasks)
        {
            var response = new TaskGetListResponse
            {
                Data = tasks.Select(CreateDto)
            };

            return response;
        }

        public TaskGetResponse CreateTaskGetResponse(Task task)
        {
            var response = new TaskGetResponse
            {
                Data = CreateDto(task)
            };

            return response;
        }
    }
}
