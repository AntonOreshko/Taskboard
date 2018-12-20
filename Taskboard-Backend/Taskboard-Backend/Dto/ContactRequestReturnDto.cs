namespace WebApi.Dto
{
    public class ContactRequestReturnDto
    {
        public long Id { get; set; }

        public long SenderId { get; set; }

        public long ReceiverId { get; set; }
    }
}