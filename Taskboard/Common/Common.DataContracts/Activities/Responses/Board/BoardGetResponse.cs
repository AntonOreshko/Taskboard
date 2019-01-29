using Common.DataContracts.Activities.Dto;

namespace Common.DataContracts.Activities.Responses.Board
{
    public class BoardGetResponse: Response
    {
        public BoardDto Data { get; set; }
    }
}