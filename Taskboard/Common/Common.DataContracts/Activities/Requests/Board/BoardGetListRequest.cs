using System;
using Common.DataContracts.Interfaces;

namespace Common.DataContracts.Activities.Requests.Board
{
    public class BoardGetListRequest: IAuthorizeRequest
    {
        public Guid UserId { get; set; }
    }
}
