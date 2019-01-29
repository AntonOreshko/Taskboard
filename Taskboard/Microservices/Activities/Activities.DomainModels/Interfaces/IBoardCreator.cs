using System;
using System.Collections.Generic;
using Activities.DomainModels.Models;
using Common.DataContracts.Activities.Requests.Board;
using Common.DataContracts.Activities.Responses.Board;

namespace Activities.DomainModels.Interfaces
{
    public interface IBoardCreator
    {
        Board CreateBoard(BoardCreateRequest boardCreateRequest);

        Board UpdateBoard(Board board, BoardUpdateRequest boardUpdateRequest);

        BoardCreateResponse CreateBoardCreateResponse(Board board);

        BoardUpdateResponse CreateBoardUpdateResponse(Board board);

        BoardDeleteResponse CreateBoardDeleteResponse(Guid id);

        BoardGetListResponse CreateBoardGetListResponse(IEnumerable<Board> boards);

        BoardGetResponse CreateBoardGetResponse(Board board);
    }
}
