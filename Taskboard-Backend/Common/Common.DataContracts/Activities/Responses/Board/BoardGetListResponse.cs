using System.Collections.Generic;
using Common.DataContracts.Activities.Dto;

namespace Common.DataContracts.Activities.Responses.Board
{
    public class BoardGetListResponse: Response
    {
        public IEnumerable<BoardDto> Data { get; set; }
    }
}
