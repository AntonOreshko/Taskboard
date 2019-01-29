using System.Threading.Tasks;
using Common.BusinessLayer.Interfaces;
using Common.DataContracts.Auth.Requests;
using Common.DataContracts.Auth.Responses;

namespace Auth.BusinessLayer.Interfaces
{
    public interface IAuthService: IService
    {
        Task<UserRegisterResponse> Register(UserRegisterRequest data);

        Task<UserLoginResponse> Login(UserLoginRequest data);
    }
}