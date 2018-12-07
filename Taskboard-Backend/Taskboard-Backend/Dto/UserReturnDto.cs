using System;

namespace WebApi.Dto
{
    public class UserReturnDto
    {
        public long Id { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public DateTime Created { get; set; }
    }
}
