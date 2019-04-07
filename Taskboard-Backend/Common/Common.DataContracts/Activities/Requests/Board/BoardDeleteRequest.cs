using System;
using Common.DataContracts.Interfaces;

namespace Common.DataContracts.Activities.Requests.Board
{
    public class BoardDeleteRequest: IAuthorizeRequest, IDeleteRequest
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
    }
}
