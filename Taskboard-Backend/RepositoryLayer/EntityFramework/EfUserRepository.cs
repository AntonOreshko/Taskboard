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

        public async Task<User> GetAsync(string email)
        {
            return await Entities.SingleOrDefaultAsync(u => u.Email == email);
        }
    }
}
