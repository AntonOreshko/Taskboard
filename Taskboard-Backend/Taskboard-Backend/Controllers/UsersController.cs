using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Services.Interfaces;
using DomainModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApi.Dto;
using WebApi.Extensions;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly IConfiguration _configuration;

        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IConfiguration configuration, IMapper mapper)
        {
            _userService = userService;
            _configuration = configuration;
            _mapper = mapper;
        }

        [HttpGet("info")]
        public async Task<IActionResult> GetUserInfo()
        {
            var userId = this.GetUserId();

            var user = await _userService.Get(userId);

            var userReturnDto = _mapper.Map<UserReturnDto>(user);

            return Ok(userReturnDto);
        }

        [HttpPut("edit")]
        public async Task<IActionResult> EditUserInfo(UserEditDto userEditDto)
        {
            var userId = this.GetUserId();

            var user = await _userService.Get(userId);

            if (user == null)
            {
                return Unauthorized();
            }

            user.Email = userEditDto.Email;
            user.FullName = userEditDto.FullName;

            user = await _userService.EditUser(user, userEditDto.OldPassword, userEditDto.NewPassword);

            var userReturnDto = _mapper.Map<UserReturnDto>(user);

            return Ok(userReturnDto);
        }
    }
}