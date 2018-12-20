namespace WebApi.Dto
{
    public class ContactCreateDto
    {
        public long Id { get; set; }

        public long FirstUserId { get; set; }

        public long SecondUserId { get; set; }
    }
}
