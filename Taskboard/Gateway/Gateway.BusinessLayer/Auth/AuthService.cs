using System.Threading.Tasks;
using Common.DataContracts.Auth.Requests;
using Common.DataContracts.Auth.Responses;
using Gateway.BusinessLayer.Interfaces.Auth;
using MassTransit;

namespace Gateway.BusinessLayer.Auth
{
    public class AuthService: IAuthService
    {
        private readonly IRequestClient<UserRegisterRequest, UserRegisterResponse> _userRegisterRequest;

        private readonly IRequestClient<UserLoginRequest, UserLoginResponse> _userLoginRequest;

        public AuthService(IRequestClient<UserLoginRequest, UserLoginResponse> userLoginRequest,
            IRequestClient<UserRegisterRequest, UserRegisterResponse> userRegisterRequest)
        {
            _userLoginRequest = userLoginRequest;
            _userRegisterRequest = userRegisterRequest;
        }

        public async Task<UserRegisterResponse> Register(UserRegisterRequest data)
        {
            return await _userRegisterRequest.Request(data);
        }

        public async Task<UserLoginResponse> Login(UserLoginRequest data)
        {
            return await _userLoginRequest.Request(data);
        }
    }
}
