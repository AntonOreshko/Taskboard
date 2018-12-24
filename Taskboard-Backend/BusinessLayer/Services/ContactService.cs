using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Services.Interfaces;
using DomainModels.Models;
using Microsoft.AspNetCore.Http.Features;
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

        public async Task<IEnumerable<long>> GetAllContactIdsByUser(long userId)
        {
            var contacts = await GetAllContactsByUser(userId);

            return contacts.Select(
                c => c.FirstUserId == userId ? c.SecondUserId : c.FirstUserId
            );
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