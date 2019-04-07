using Common.DataContracts.Interfaces;

namespace Common.DataContracts.Auth.Requests
{
    public class UserLoginRequest: IRequest
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
