using System;

namespace WebApi.Dto
{
    public class BoardReturnDto
    {
        public long Id { get; set; }

        public DateTime Created { get; set; }

        public long CreatedById { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
