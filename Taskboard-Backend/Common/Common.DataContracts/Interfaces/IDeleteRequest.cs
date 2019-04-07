using System;

namespace Common.DataContracts.Interfaces
{
    public interface IDeleteRequest: IRequest
    {
        Guid Id { get; set; }
    }
}
