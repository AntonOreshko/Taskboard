using Common.DataContracts.Auth.Responses;

namespace Common.JWT
{
    public interface IJwtTokenService
    {
        string GenerateToken(UserLoginResponse user);
    }
}