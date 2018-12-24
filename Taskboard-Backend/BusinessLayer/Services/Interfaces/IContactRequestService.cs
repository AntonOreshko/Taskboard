using System.Collections.Generic;
using System.Threading.Tasks;
using DomainModels.Models;
using RepositoryLayer.Repository;

namespace BusinessLayer.Services.Interfaces
{
    public interface IContactRequestService : IDatabaseItemService<ContactRequest>
    {
        IContactRequestRepository ContactRequestRepository { get; set; }

        Task<IEnumerable<ContactRequest>> GetAllContactRequestsByUser(long userId);

        Task<IEnumerable<ContactRequest>> GetAllIncomingContactRequestsByUser(long userId);

        Task<IEnumerable<ContactRequest>> GetAllOutgoingContactRequestsByUser(long userId);

        Task<ContactRequest> CreateContactRequest(ContactRequest contactRequest);

        Task<bool> AcceptContactRequest(ContactRequest contactRequest);

        Task<bool> CancelContactRequest(ContactRequest contactRequest);

        Task<bool> RejectContactRequest(ContactRequest contactRequest);
    }
}
