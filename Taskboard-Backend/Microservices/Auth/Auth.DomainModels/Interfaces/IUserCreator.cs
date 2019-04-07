using Auth.DomainModels.Models;
using Common.DataContracts.Auth.Requests;
using Common.DataContracts.Auth.Responses;

namespace Auth.DomainModels.Interfaces
{
    public interface IUserCreator
    {
        User CreateUser(UserRegisterRequest userRegisterRequest);

        UserRegisterResponse CreateUserRegistered(User user);

        UserLoginResponse CreateUserLoggedIn(User user);
    }
}