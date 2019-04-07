using Common.DataContracts.Enums;
using Common.DataContracts.Errors;

namespace Common.DataContracts.Interfaces
{
    public interface IResponse
    {
        ResponseStatus ResponseStatus { get; set; }

        ResponseError Error { get; set; }
    }
}
