using System.Threading.Tasks;
using Auth.BusinessLayer.Interfaces;
using Auth.DomainModels.Interfaces;
using Auth.Repository.Interfaces;
using Common.DataContracts.Auth.Requests;
using Common.DataContracts.Auth.Responses;
using Common.Errors;

namespace Auth.BusinessLayer
{
    public class AuthService: IAuthService
    {
        private readonly IUserEfRepository _userEfRepository;

        private readonly IPasswordCreator _passwordCreator;

        private readonly IUserCreator _userCreator;

        public AuthService(IUserEfRepository userEfRepository,
            IPasswordCreator passwordCreator,
            IUserCreator userCreator)
        {
            _userEfRepository = userEfRepository;
            _passwordCreator = passwordCreator;
            _userCreator = userCreator;
        }

        public async Task<UserRegisterResponse> Register(UserRegisterRequest data)
        {
            UserRegisterResponse userRegisterResponse;

            var user = await _userEfRepository.GetAsync(data.Email);
            if (user != null)
            {
                userRegisterResponse = _userCreator.CreateUserRegistered(user);
                userRegisterResponse.Failed(ErrorManager.GetById(15));

                return userRegisterResponse;
            }

            user = _userCreator.CreateUser(data);

            await _userEfRepository.InsertAsync(user);

            await _userEfRepository.SaveChangesAsync();

            userRegisterResponse = _userCreator.CreateUserRegistered(user);
            userRegisterResponse.Succeeded();

            return userRegisterResponse;
        }

        public async Task<UserLoginResponse> Login(UserLoginRequest data)
        {
            UserLoginResponse userLoginResponse;

            var user = await _userEfRepository.GetAsync(data.Email);

            if (user == null)
            {
                userLoginResponse = new UserLoginResponse();
                userLoginResponse.Failed(ErrorManager.GetById(65));

                return userLoginResponse;
            }

            if (!_passwordCreator.VerifyPasswordHash(data.Password, user.PasswordHash, user.PasswordSalt))
            {
                userLoginResponse = _userCreator.CreateUserLoggedIn(user);
                userLoginResponse.Failed(ErrorManager.GetById(66));

                return userLoginResponse;
            }

            userLoginResponse = _userCreator.CreateUserLoggedIn(user);
            userLoginResponse.Succeeded();

            return userLoginResponse;
        }
    }
}
