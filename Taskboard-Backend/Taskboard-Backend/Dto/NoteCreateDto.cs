﻿namespace WebApi.Dto
{
    public class NoteCreateDto
    {
        public long BoardId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
