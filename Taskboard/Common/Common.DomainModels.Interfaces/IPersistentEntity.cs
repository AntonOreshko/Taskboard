using System;

namespace Common.DomainModels.Interfaces
{
    public interface IPersistentEntity
    {
        Guid Id { get; set; }
    }
}
