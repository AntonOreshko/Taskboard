using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Services.Interfaces;
using DomainModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        private readonly IContactService _contactService;

        private readonly IContactRequestService _contactRequestService;

        private readonly IMapper _mapper;

        public UsersController(IUserService userService, 
                               IMapper mapper,
                               IContactService contactService, 
                               IContactRequestService contactRequestService)
        {
            _userService = userService;
            _mapper = mapper;
            _contactService = contactService;
            _contactRequestService = contactRequestService;
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

        [HttpGet("search/{filter}")]
        public async Task<IActionResult> SearchUsers(string filter)
        {
            var users = await _userService.SearchUsers(filter);

            var usersToReturn = _mapper.Map<IEnumerable<UserReturnDto>>(users);

            return Ok(usersToReturn);
        }

        [HttpGet("contacts")]
        public async Task<IActionResult> GetContacts()
        {
            var ids = await _contactService.GetAllContactIdsByUser(this.GetUserId());

            var userContacts = await _userService.GetUsersIn(ids);

            var usersReturnDto = _mapper.Map<IEnumerable<UserReturnDto>>(userContacts);

            return Ok(usersReturnDto);
        }

        [HttpGet("contacts/{filter}")]
        public async Task<IActionResult> SearchContacts(string filter)
        {
            var ids = await _contactService.GetAllContactIdsByUser(this.GetUserId());

            var userContacts = await _userService.SearchUsersIn(filter, ids);

            var usersReturnDto = _mapper.Map<IEnumerable<UserReturnDto>>(userContacts);

            return Ok(usersReturnDto);
        }

        [HttpPost("invite/{userId}")]
        public async Task<IActionResult> InviteUser(ContactRequestCreateDto contactRequestCreateDto)
        {
            if (contactRequestCreateDto.SenderId != this.GetUserId())
            {
                return Unauthorized();
            }

            var request = _mapper.Map<ContactRequest>(contactRequestCreateDto);

            var resultRequest = await _contactRequestService.CreateContactRequest(request);

            return Ok(resultRequest);
        }

        [HttpPost("cancel-invitation/{invitationId}")]
        public async Task<IActionResult> CancelUserInvitation(long invitationId)
        {
            var contactRequest = await _contactRequestService.Get(invitationId);

            if (contactRequest.SenderId != this.GetUserId())
            {
                return Unauthorized();
            }

            var result = await _contactRequestService.CancelContactRequest(contactRequest);

            return Ok(result);
        }

        [HttpPost("accept-invitation/{invitationId}")]
        public async Task<IActionResult> AcceptUserInvitation(long invitationId)
        {
            var contactRequest = await _contactRequestService.Get(invitationId);

            if (contactRequest.ReceiverId != this.GetUserId())
            {
                return Unauthorized();
            }

            var contact = _mapper.Map<Contact>(contactRequest);

            var result = await _contactRequestService.AcceptContactRequest(contactRequest);

            var resultContact = await _contactService.CreateContact(contact);

            return Ok(resultContact);
        }

        [HttpPost("reject-invitation/{invitationId}")]
        public async Task<IActionResult> RejectUserInvitation(long invitationId)
        {
            var contactRequest = await _contactRequestService.Get(invitationId);

            if (contactRequest.ReceiverId != this.GetUserId())
            {
                return Unauthorized();
            }

            var result = await _contactRequestService.RejectContactRequest(contactRequest);

            return Ok(result);
        }
    }
}
