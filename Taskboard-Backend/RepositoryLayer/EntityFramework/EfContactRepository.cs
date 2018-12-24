using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.EntityFramework.Context;
using RepositoryLayer.Repository;

namespace RepositoryLayer.EntityFramework
{
    public class EfContactRepository: EfRepository<Contact>, IContactRepository
    {
        public EfContactRepository(TaskboardContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Contact>> GetByUser(long userId)
        {
            return await Entities.Where(c => c.FirstUserId == userId || c.SecondUserId == userId).ToListAsync();
        }

        public async Task<bool> IsContact(long userId, long contactId)
        {
            return await Entities
                .Where(c => c.FirstUserId == userId || c.SecondUserId == userId)
                .AnyAsync(c => c.FirstUserId == contactId || c.SecondUserId == contactId);
        }
    }
}
