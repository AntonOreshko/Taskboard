using System;

namespace Common.DataContracts.Interfaces
{
    public interface IAuthorizeRequest: IRequest
    {
        Guid UserId { get; set; }
    }
}