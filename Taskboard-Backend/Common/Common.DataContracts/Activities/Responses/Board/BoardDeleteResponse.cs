using System;
using Common.DataContracts.Interfaces;

namespace Common.DataContracts.Activities.Responses.Board
{
    public class BoardDeleteResponse: Response, IDeleteResponse
    {
        public Guid Id { get; set; }
    }
}
