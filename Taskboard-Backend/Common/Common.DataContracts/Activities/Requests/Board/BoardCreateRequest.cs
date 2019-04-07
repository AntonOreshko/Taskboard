﻿using System;
using Common.DataContracts.Interfaces;

namespace Common.DataContracts.Activities.Requests.Board
{
    public class BoardCreateRequest: IAuthorizeRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Guid UserId { get; set; }
    }
}
