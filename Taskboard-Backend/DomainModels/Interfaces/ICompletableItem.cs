using DomainModels.Models;

namespace DomainModels.Interfaces
{
    public interface ICompletableItem
    {
        bool Completed { get; set; }

        long? CompletedById { get; set; }

        User CompletedBy { get; set; }
    }
}
