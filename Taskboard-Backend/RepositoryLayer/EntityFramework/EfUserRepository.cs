using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.EntityFramework.Context;
using RepositoryLayer.Repository;

namespace RepositoryLayer.EntityFramework
{
    public class EfUserRepository : EfRepository<User>, IUserRepository
    {
        public EfUserRepository(TaskboardContext context) : base(context)
        {

        }

        public async Task<bool> ContainsAsync(string email)
        {
            return await Entities.AnyAsync(u => u.Email == email);
        }

        public async Task<IEnumerable<User>> GetUsersIn(IEnumerable<long> ids)
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

        public async Task<IEnumerable<User>> SearchUsersIn(string filter, IEnumerable<long> ids)
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
