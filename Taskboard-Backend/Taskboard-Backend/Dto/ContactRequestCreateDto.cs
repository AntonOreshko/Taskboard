namespace WebApi.Dto
{
    public class ContactRequestCreateDto
    {
        public long Id { get; set; }

        public long SenderId { get; set; }

        public long ReceiverId { get; set; }
    }
}