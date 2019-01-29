using System.Threading.Tasks;
using Common.DataContracts.Auth.Requests;
using Common.DataContracts.Enums;
using Common.JWT;
using Common.Middleware.ExceptionsFilter;
using Gateway.BusinessLayer.Interfaces.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExceptionFilter]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        private readonly IJwtTokenService _jwtTokenService;

        public AuthController(IAuthService authService,
            IJwtTokenService jwtTokenService)
        {
            _authService = authService;
            _jwtTokenService = jwtTokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterRequest userRegisterRequest)
        {
            var userRegisterResult = await _authService.Register(userRegisterRequest);
            if (userRegisterResult.ResponseStatus == ResponseStatus.Succeeded)
            {
                return Created(string.Empty, userRegisterResult);
            }

            return StatusCode((int) userRegisterResult.Error.HttpStatusCode, userRegisterResult);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginRequest userLoginRequest)
        {
            var userLoggedInResult = await _authService.Login(userLoginRequest);
            if (userLoggedInResult.ResponseStatus == ResponseStatus.Succeeded)
            {
                var token = _jwtTokenService.GenerateToken(userLoggedInResult);

                return Ok(new
                {
                    userLoggedInResult.Data,
                    userLoggedInResult.ResponseStatus,
                    Token = token,
                    userLoggedInResult.Error
                });
            }

            return StatusCode((int) userLoggedInResult.Error.HttpStatusCode, userLoggedInResult);
        }
    }
}
