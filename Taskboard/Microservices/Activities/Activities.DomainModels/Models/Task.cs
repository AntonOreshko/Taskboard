using System;
using Common.DomainModels.Interfaces;

namespace Activities.DomainModels.Models
{
    public class Task: IPersistentEntity
    {
        public Guid Id { get; set; }

        public DateTime Created { get; set; }

        public Guid CreatedById { get; set; }

        public Guid BoardId { get; set; }

        public bool Completed { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}