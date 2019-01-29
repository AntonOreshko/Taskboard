using System;
using Common.DataContracts.Interfaces;

namespace Common.DataContracts.Activities.Requests.Task
{
    public class TaskCreateRequest: IAuthorizeRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Guid BoardId { get; set; }

        public Guid UserId { get; set; }
    }
}
