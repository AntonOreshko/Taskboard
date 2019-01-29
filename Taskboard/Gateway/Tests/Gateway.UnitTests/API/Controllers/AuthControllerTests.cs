using System.Net;
using System.Threading.Tasks;
using Common.BusinessLayer.Interfaces;
using Common.DataContracts.Auth.Requests;
using Common.DataContracts.Auth.Responses;
using Common.DataContracts.Enums;
using Common.DataContracts.Errors;
using Common.JWT;
using Gateway.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace Gateway.UnitTests.API.Controllers
{
    [TestFixture]
    public class AuthControllerTests
    {
        private Mock<IAuthService> _service;

        private Mock<IJwtTokenService> _jwtTokenService;

        private UserRegisterRequest _userRegisterRequest;

        private UserLoginRequest _userLoginRequest;

        private AuthController _authController;

        [SetUp]
        public void SetUp()
        {
            _userRegisterRequest = new UserRegisterRequest
            {
                Email = "test@gmail.com",
                FullName = "Test User",
                Password = "password"
            };
            _userLoginRequest = new UserLoginRequest
            {
                Email = "test@gmail.com",
                Password = "password"
            };
            _service = new Mock<IAuthService>();

            _jwtTokenService = new Mock<IJwtTokenService>();
            _jwtTokenService
                .Setup(j => j.GenerateToken(new UserLoginResponse()))
                .Returns(() => "jwt.token.example");

            _authController = new AuthController(_service.Object, _jwtTokenService.Object);
        }

        [Test]
        public async Task Register_WhenCalled_ReturnCreatedResult()
        {
            _service
                .Setup(s => s.Register(_userRegisterRequest))
                .ReturnsAsync(() => new UserRegisterResponse()
                {
                    ResponseStatus = ResponseStatus.Succeeded,
                    Error = null
                });

            var result = await _authController.Register(_userRegisterRequest);

            Assert.IsInstanceOf<CreatedResult>(result);
        }

        [Test]
        public async Task Register_ExistingEmailPassed_ReturnHttpStatusCode400()
        {
            _service
                .Setup(s => s.Register(_userRegisterRequest))
                .ReturnsAsync(() => new UserRegisterResponse()
                {
                    ResponseStatus = ResponseStatus.Failed,
                    Error = new ResponseError { Code = 211, HttpStatusCode = HttpStatusCode.BadRequest }
                });

            var result = await _authController.Register(_userRegisterRequest);
            var objResult = result as ObjectResult;

            Assert.That(objResult.StatusCode, Is.EqualTo(400));
        }

        [Test]
        public async Task Login_WhenCalled_ReturnOkObjectResult()
        {
            _service
                .Setup(s => s.Login(_userLoginRequest))
                .ReturnsAsync(() => new UserLoginResponse()
                {
                    ResponseStatus = ResponseStatus.Succeeded,
                    Error = null
                });

            var result = await _authController.Login(_userLoginRequest);

            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public async Task Login_WrongEmailPassed_ReturnHttpStatusCode403()
        {
            _service
                .Setup(s => s.Login(_userLoginRequest))
                .ReturnsAsync(() => new UserLoginResponse()
                {
                    ResponseStatus = ResponseStatus.Failed,
                    Error = new ResponseError { Code = 205, HttpStatusCode = HttpStatusCode.Forbidden }
                });

            var result = await _authController.Login(_userLoginRequest);
            var objResult = result as ObjectResult;

            Assert.That(objResult.StatusCode, Is.EqualTo(403));
        }

        [Test]
        public async Task Login_WrongPasswordPassed_ReturnHttpStatusCode403()
        {
            _service
                .Setup(s => s.Login(_userLoginRequest))
                .ReturnsAsync(() => new UserLoginResponse()
                {
                    ResponseStatus = ResponseStatus.Failed,
                    Error = new ResponseError { Code = 205, HttpStatusCode = HttpStatusCode.Forbidden }
                });

            var result = await _authController.Login(_userLoginRequest);
            var objResult = result as ObjectResult;

            Assert.That(objResult.StatusCode, Is.EqualTo(403));
        }

    }
}
