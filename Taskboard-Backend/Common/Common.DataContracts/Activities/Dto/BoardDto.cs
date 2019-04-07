using System;

namespace Common.DataContracts.Activities.Dto
{
    public class BoardDto
    {
        public Guid Id { get; set; }

        public DateTime Created { get; set; }

        public Guid CreatedById { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
