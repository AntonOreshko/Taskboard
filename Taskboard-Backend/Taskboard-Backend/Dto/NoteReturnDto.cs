using System;

namespace WebApi.Dto
{
    public class NoteReturnDto
    {
        public long Id { get; set; }

        public DateTime Created { get; set; }

        public long CreatedById { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public long BoardId { get; set; }
    }
}
