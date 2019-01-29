using System;

namespace Common.DataContracts.Activities.Dto
{
    public class TaskDto
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
