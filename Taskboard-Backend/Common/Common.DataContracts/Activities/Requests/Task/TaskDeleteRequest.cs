using System;
using Common.DataContracts.Interfaces;

namespace Common.DataContracts.Activities.Requests.Task
{
    public class TaskDeleteRequest: IAuthorizeRequest, IDeleteRequest
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid BoardId { get; set; }
    }
}
