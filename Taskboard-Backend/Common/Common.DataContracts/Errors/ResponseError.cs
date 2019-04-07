using System.Net;
using Common.Errors;

namespace Common.DataContracts.Errors
{
    public class ResponseError
    {
        public short Code { get; set; }

        public HttpStatusCode HttpStatusCode { get; set; }

        public int StatusCode { get; set; }

        public string Message { get; set; }

        public string StackTrace { get; set; }

        public ResponseError()
        {
            
        }

        public ResponseError(Error error)
        {
            Code = error.ErrorCode;
            HttpStatusCode = error.HttpStatusCode;
            StatusCode = error.StatusCode;
            Message = error.ErrorMessage;
        }
    }
}
