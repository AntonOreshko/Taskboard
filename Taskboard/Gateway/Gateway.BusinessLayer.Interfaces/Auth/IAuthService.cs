using System.Threading.Tasks;
using Common.BusinessLayer.Interfaces;
using Common.DataContracts.Auth.Requests;
using Common.DataContracts.Auth.Responses;

namespace Gateway.BusinessLayer.Interfaces.Auth
{
    public interface IAuthService: IService
    {
        Task<UserRegisterResponse> Register(UserRegisterRequest data);

        Task<UserLoginResponse> Login(UserLoginRequest data);
    }
}
