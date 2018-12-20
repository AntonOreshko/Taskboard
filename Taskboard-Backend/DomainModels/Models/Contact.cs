using DomainModels.Interfaces;

namespace DomainModels.Models
{
    public class Contact : IDatabaseItem
    {
        public long Id { get; set; }

        public long FirstUserId { get; set; }

        public User FirstUser { get; set; }

        public long SecondUserId { get; set; }

        public User SecondUser { get; set; }
    }
}
