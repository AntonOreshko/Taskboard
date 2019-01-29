using System;
using Common.DataContracts.Interfaces;

namespace Common.DataContracts.Activities.Requests.Board
{
    public class BoardGetRequest: IAuthorizeRequest
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
    }
}
