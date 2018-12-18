using DomainModels.Interfaces;
using System;

namespace DomainModels.Models
{
    public class Note : IDatabaseItem, ICreatableItem, IDescriptableItem
    {
        public long Id { get; set; }

        public DateTime Created { get; set; }

        public long CreatedById { get; set; }

        public User CreatedBy { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public long BoardId { get; set; }

        public Board Board { get; set; }
    }
}
