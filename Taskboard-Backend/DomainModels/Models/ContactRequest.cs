using DomainModels.Interfaces;

namespace DomainModels.Models
{
    public class ContactRequest : IDatabaseItem
    {
        public long Id { get; set; }

        public long SenderId { get; set; }

        public User Sender { get; set; }

        public long ReceiverId { get; set; }

        public User Receiver { get; set; }

    }
}
