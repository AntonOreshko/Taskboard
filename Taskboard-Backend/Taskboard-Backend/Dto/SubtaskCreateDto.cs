namespace WebApi.Dto
{
    public class SubtaskCreateDto
    {
        public long TaskId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
