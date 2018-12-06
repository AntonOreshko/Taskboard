using DomainModels.Interfaces;

namespace DomainModels.Models
{
    public class UserBoard : IDatabaseItem
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public User User { get; set; }

        public long BoardId { get; set; }

        public Board Board { get; set; }
    }
}
