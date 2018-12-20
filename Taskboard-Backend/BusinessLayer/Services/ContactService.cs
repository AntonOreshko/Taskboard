using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Services.Interfaces;
using DomainModels.Models;
using RepositoryLayer.Repository;

namespace BusinessLayer.Services
{
    public class ContactService : DatabaseItemService<Contact>, IContactService
    {
        public IContactRepository ContactRepository { get; set; }

        public ContactService(IRepository<Contact> repo, IContactRepository customRepo) : base(repo)
        {
            ContactRepository = customRepo;
        }

        public async Task<IEnumerable<Contact>> GetAllContactsByUser(long userId)
        {
            return await ContactRepository.GetByUser(userId);
        }

        public async Task<Contact> CreateContact(Contact contact)
        {
            await Add(contact);

            return contact;
        }

        public async Task<bool> DeleteContact(Contact contact)
        {
            await Remove(contact);

            return true;
        }
    }
}