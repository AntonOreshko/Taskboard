using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Services.Interfaces;
using DomainModels.Models;
using RepositoryLayer.Repository;

namespace BusinessLayer.Services
{
    public class ContactRequestService : DatabaseItemService<ContactRequest>, IContactRequestService
    {
        public IContactRequestRepository ContactRequestRepository { get; set; }

        public ContactRequestService(IRepository<ContactRequest> repo, IContactRequestRepository customRepo) : base(repo)
        {
            ContactRequestRepository = customRepo;
        }

        public async Task<IEnumerable<ContactRequest>> GetAllContactRequestsByUser(long userId)
        {
            return await ContactRequestRepository.GetByUser(userId);
        }

        public async Task<IEnumerable<ContactRequest>> GetAllIncomingContactRequestsByUser(long userId)
        {
            return await ContactRequestRepository.GetIncomingByUser(userId);
        }

        public async Task<IEnumerable<ContactRequest>> GetAllOutgoingContactRequestsByUser(long userId)
        {
            return await ContactRequestRepository.GetOutgoingByUser(userId);
        }

        public async Task<ContactRequest> CreateContactRequest(ContactRequest contactRequest)
        {
            await Add(contactRequest);

            return contactRequest;
        }

        public async Task<ContactRequest> AcceptContactRequest(ContactRequest contactRequest)
        {
            await Remove(contactRequest);

            return contactRequest;
        }

        public async Task<bool> CancelContactRequest(ContactRequest contactRequest)
        {
            await Remove(contactRequest);

            return true;
        }

        public async Task<bool> RejectContactRequest(ContactRequest contactRequest)
        {
            await Remove(contactRequest);

            return true;
        }
    }
}