using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.EntityFramework.Context;
using RepositoryLayer.Repository;

namespace RepositoryLayer.EntityFramework
{
    public class EfContactRequestRepository : EfRepository<ContactRequest>, IContactRequestRepository
    {
        public EfContactRequestRepository(TaskboardContext context) : base(context)
        {

        }

        public async Task<IEnumerable<ContactRequest>> GetByUser(long userId)
        {
            return await Entities.Where(c => c.SenderId == userId || c.ReceiverId == userId).ToListAsync();
        }

        public async Task<IEnumerable<ContactRequest>> GetIncomingByUser(long userId)
        {
            return await Entities.Where(c => c.ReceiverId == userId).ToListAsync();
        }

        public async Task<IEnumerable<ContactRequest>> GetOutgoingByUser(long userId)
        {
            return await Entities.Where(c => c.SenderId == userId).ToListAsync();
        }
    }
}