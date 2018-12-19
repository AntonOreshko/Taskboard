using System;

namespace WebApi.Dto
{
    public class SubtaskReturnDto
    {
        public long Id { get; set; }

        public DateTime Created { get; set; }

        public long CreatedById { get; set; }

        public bool Completed { get; set; }

        public long? CompletedById { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public long TaskId { get; set; }
    }
}
