using System;
using Common.DomainModels.Interfaces;

namespace Activities.DomainModels.Models
{
    public class Board: IPersistentEntity
    {
        public Guid Id { get; set; }

        public DateTime Created { get; set; }

        public Guid CreatedById { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
