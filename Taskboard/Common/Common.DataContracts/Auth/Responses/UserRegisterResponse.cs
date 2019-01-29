using Common.DataContracts.Auth.Dto;

namespace Common.DataContracts.Auth.Responses
{
    public class UserRegisterResponse: Response
    {
        public UserDto Data { get; set; }
    }
}
