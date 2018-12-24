using System.Collections.Generic;
using System.Threading.Tasks;
using DomainModels.Models;

namespace RepositoryLayer.Repository
{
    public interface IContactRepository: IRepository<Contact>
    {
        Task<IEnumerable<Contact>> GetByUser(long userId);

        Task<bool> IsContact(long id, long contactId);
    }
}