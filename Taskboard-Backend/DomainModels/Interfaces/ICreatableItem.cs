using DomainModels.Models;
using System;

namespace DomainModels.Interfaces
{
    public interface ICreatableItem
    {
        DateTime Created { get; set; }

        long CreatedById { get; set; }

        User CreatedBy { get; set; }
    }
}
