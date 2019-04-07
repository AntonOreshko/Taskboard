using Common.DataContracts.Interfaces;

namespace Common.DataContracts.Auth.Requests
{
    public class UserRegisterRequest: IRequest
    {
        public string Email { get; set; }

        public string FullName { get; set; }

        public string Password { get; set; }
    }
}
