using System;

namespace Common.DataContracts.Auth.Dto
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public DateTime Created { get; set; }
    }
}
