using System.Collections.Generic;
using System.Threading.Tasks;
using DomainModels.Models;

namespace RepositoryLayer.Repository
{
    public interface IContactRequestRepository: IRepository<ContactRequest>
    {
        Task<IEnumerable<ContactRequest>> GetByUser(long userId);

        Task<IEnumerable<ContactRequest>> GetIncomingByUser(long userId);

        Task<IEnumerable<ContactRequest>> GetOutgoingByUser(long userId);
    }
}