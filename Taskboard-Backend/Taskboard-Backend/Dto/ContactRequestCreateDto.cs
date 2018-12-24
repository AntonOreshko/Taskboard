namespace WebApi.Dto
{
    public class ContactRequestCreateDto
    {
        public long SenderId { get; set; }

        public long ReceiverId { get; set; }
    }
}