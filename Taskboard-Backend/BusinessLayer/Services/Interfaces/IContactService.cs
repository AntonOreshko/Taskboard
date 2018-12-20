using System.Collections.Generic;
using System.Threading.Tasks;
using DomainModels.Models;
using RepositoryLayer.Repository;

namespace BusinessLayer.Services.Interfaces
{
    public interface IContactService : IDatabaseItemService<Contact>
    {
        IContactRepository ContactRepository { get; set; }

        Task<IEnumerable<Contact>> GetAllContactsByUser(long userId);

        Task<Contact> CreateContact(Contact contact);

        Task<bool> DeleteContact(Contact contact);
    }
}
