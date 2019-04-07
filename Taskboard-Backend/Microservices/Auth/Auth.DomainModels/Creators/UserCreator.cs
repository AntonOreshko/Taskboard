using System;
using Auth.DomainModels.Interfaces;
using Auth.DomainModels.Models;
using Common.DataContracts.Auth.Dto;
using Common.DataContracts.Auth.Requests;
using Common.DataContracts.Auth.Responses;

namespace Auth.DomainModels.Creators
{
    public class UserCreator: IUserCreator
    {
        private readonly IPasswordCreator _passwordCreator;

        public UserCreator(IPasswordCreator passwordCreator)
        {
            _passwordCreator = passwordCreator;
        }

        public User CreateUser(UserRegisterRequest userRegisterRequest)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                FullName = userRegisterRequest.FullName,
                Email = userRegisterRequest.Email,
                Created = DateTime.UtcNow
            };

            _passwordCreator.CreatePasswordHash(userRegisterRequest.Password, 
                out byte[] hash, out byte[] salt);

            user.PasswordHash = hash;
            user.PasswordSalt = salt;

            return user;
        }

        private UserDto CreateDto(User user)
        {
            var userDto = new UserDto
            {
                Id = user.Id, Email = user.Email, FullName = user.FullName, Created = user.Created
            };

            return userDto;
        }

        public UserRegisterResponse CreateUserRegistered(User user)
        {
            var userRegistered = new UserRegisterResponse
            {
                Data = CreateDto(user)
            };

            return userRegistered;
        }

        public UserLoginResponse CreateUserLoggedIn(User user)
        {
            var userLoggedIn = new UserLoginResponse
            {
                Data = CreateDto(user)
            };

            return userLoggedIn;
        }
    }
}
