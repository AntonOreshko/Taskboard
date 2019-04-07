using System;
using System.Collections.Generic;
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

        public List<Task> Tasks { get; set; }
    }
}
