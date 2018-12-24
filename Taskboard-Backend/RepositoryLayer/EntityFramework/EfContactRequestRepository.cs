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

        public async Task<bool> IsContactRequestSent(long userId, long requestedId)
        {
            return await Entities
                .Where(c => c.SenderId == userId)
                .AnyAsync(c => c.ReceiverId == requestedId);
        }

        public async Task<bool> IsContactRequestReceived(long userId, long requestedFrom)
        {
            return await Entities
                .Where(c => c.SenderId == requestedFrom)
                .AnyAsync(c => c.ReceiverId == userId);
        }
    }
}