using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth.DomainModels.Models;
using Auth.Repository.EntityFramework.Context;
using Auth.Repository.Interfaces;
using Common.Repository;
using Microsoft.EntityFrameworkCore;

namespace Auth.Repository.EntityFramework
{
    public class EfEfUserRepository : EfEfRepository<User>, IUserEfRepository
    {
        public EfEfUserRepository(AuthContext context) : base(context)
        {

        }

        public async Task<bool> ContainsAsync(string email)
        {
            return await Entities.AnyAsync(u => u.Email == email);
        }

        public async Task<IEnumerable<User>> GetUsersIn(IEnumerable<Guid> ids)
        {
            return await Entities
                .Where(u => ids.Contains(u.Id))
                .ToListAsync();
        }

        public async Task<IEnumerable<User>> SearchUsers(string filter)
        {
            return await Entities
                .Where(u => u.FullName.Contains(filter) || u.Email.Contains(filter))
                .ToListAsync();
        }

        public async Task<IEnumerable<User>> SearchUsersIn(string filter, IEnumerable<Guid> ids)
        {
            return await Entities
                .Where(u => ids.Contains(u.Id))
                .Where(u => u.FullName.Contains(filter) || u.Email.Contains(filter))
                .ToListAsync();
        }

        public async Task<User> GetAsync(string email)
        {
            return await Entities.SingleOrDefaultAsync(u => u.Email == email);
        }
    }
}