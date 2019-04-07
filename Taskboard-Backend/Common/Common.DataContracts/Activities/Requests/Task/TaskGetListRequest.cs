using System;
using Common.DataContracts.Interfaces;

namespace Common.DataContracts.Activities.Requests.Task
{
    public class TaskGetListRequest: IAuthorizeRequest
    {
        public Guid UserId { get; set; }

        public Guid BoardId { get; set; }
    }
}
