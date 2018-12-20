using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Services.Interfaces;
using DomainModels.Models;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Repository;

namespace BusinessLayer.Services
{
    public class UserService : DatabaseItemService<User>, IUserService
    {
        public IUserRepository UserRepository { get; set; }

        private IConfiguration _configuration { get; set; }

        public UserService(IRepository<User> repo, IUserRepository customRepo, IConfiguration configuration): base(repo)
        {
            UserRepository = customRepo;
            _configuration = configuration;
        }

        public async Task<User> Get(string email)
        {
            return await UserRepository.GetAsync(email);
        }

        public async Task<bool> Exists(string email)
        {
            return await UserRepository.ContainsAsync(email);
        }

        public async Task<User> Register(User user, string password)
        {
            CreatePasswordHash(password, out var passwordHash, out var passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Created = DateTime.Now;

            await Add(user);

            return user;
        }

        public async Task<User> Login(string email, string password)
        {
            var user = await Get(email);

            if (user == null) return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }

            return user;
        }

        public async Task<User> EditUser(User user, string oldPassword = null, string newPassword = null)
        {
            if (string.IsNullOrEmpty(newPassword))
            {
                await Change(user);

                return user;
            }

            if (string.IsNullOrEmpty(oldPassword))
            {
                return user;
            }

            if (VerifyPasswordHash(oldPassword, user.PasswordHash, user.PasswordSalt))
            {
                CreatePasswordHash(newPassword, out var passwordHash, out var passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                await Change(user);
            }

            return user;
        }

        public async Task<IEnumerable<User>> SearchUsers(string filter)
        {
            return await UserRepository.SearchUsers(filter);
        }

        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            }

            return true;
        }

    }
}
