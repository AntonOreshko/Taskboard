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

        BoardCreateResponse CreateBoardCreated(Board board);

        BoardUpdateResponse CreateBoardUpdated(Board board);

        BoardDeleteResponse CreateBoardDeleted(Guid id);

        BoardGetListResponse CreateBoardGetListResponse(IEnumerable<Board> boards);

        BoardGetResponse CreateBoardGetResponse(Board board);
    }
}
