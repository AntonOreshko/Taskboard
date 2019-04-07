﻿using System;
using Common.DataContracts.Interfaces;

namespace Common.DataContracts.Activities.Requests.Task
{
    public class TaskGetRequest: IAuthorizeRequest
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid BoardId { get; set; }
    }
}
