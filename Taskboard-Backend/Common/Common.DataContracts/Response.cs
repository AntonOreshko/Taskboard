using Common.DataContracts.Enums;
using Common.DataContracts.Errors;
using Common.DataContracts.Interfaces;
using Common.Errors;

namespace Common.DataContracts
{
    public class Response: IResponse
    {
        public ResponseStatus ResponseStatus { get; set; }

        public ResponseError Error { get; set; }

        public void Succeeded()
        {
            ResponseStatus = ResponseStatus.Succeeded;
        }

        public void Failed(Error error)
        {
            ResponseStatus = ResponseStatus.Failed;
            Error = new ResponseError(error);
        }
    }
}