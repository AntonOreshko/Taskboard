using System;
using System.Collections.Generic;
using DomainModels.Interfaces;

namespace DomainModels.Models
{
    public class Board : IDatabaseItem, ICreatableItem, IDescriptableItem
    {
        public long Id { get; set; }

        public DateTime Created { get; set; }

        public long CreatedById { get; set; }

        public User CreatedBy { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<UserBoard> UserBoards { get; set; }

        public List<Task> Tasks { get; set; }

        public List<Task> Notes { get; set; }
    }
}
