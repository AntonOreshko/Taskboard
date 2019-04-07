using System;
using System.Net;

namespace Common.Errors
{
    [Serializable]
    public class Error
    {
        public short Id { get; set; }

        public short ErrorCode { get; set; }

        public HttpStatusCode HttpStatusCode { get; set; }

        public short StatusCode { get; set; }

        public string ErrorMessage { get; set; }

        public string Scope { get; set; }

        public string Description { get; set; }
    }
}
