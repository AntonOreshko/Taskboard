using System;
using Common.DataContracts.Interfaces;

namespace Common.DataContracts.Activities.Responses.Task
{
    public class TaskDeleteResponse: Response, IDeleteResponse
    {
        public Guid Id { get; set; }
    }
}
