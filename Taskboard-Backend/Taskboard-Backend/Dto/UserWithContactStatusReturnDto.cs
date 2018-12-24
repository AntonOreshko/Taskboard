using WebApi.Enums;

namespace WebApi.Dto
{
    public class UserWithContactStatusReturnDto: UserReturnDto
    {
        public UserContactStatus ContactStatus { get; set; }
    }
}
