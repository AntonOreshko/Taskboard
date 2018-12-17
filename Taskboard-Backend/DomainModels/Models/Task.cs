using DomainModels.Interfaces;
using System;
using System.Collections.Generic;

namespace DomainModels.Models
{
    public class Task : IDatabaseItem, ICreatableItem, ICompletableItem, IDescriptableItem
    {
        public long Id { get; set; }

        public DateTime Created { get; set; }

        public long CreatedById { get; set; }

        public User CreatedBy { get; set; }

        public bool Completed { get; set; }

        public long? CompletedById { get; set; }

        public User CompletedBy { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public long BoardId { get; set; }

        public Board Board { get; set; }

        public List<Subtask> Subtasks { get; set; }
    }
}
