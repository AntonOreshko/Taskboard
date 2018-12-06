using DomainModels.Models;
using RepositoryLayer.Repository;

namespace BusinessLayer.Services.Interfaces
{
    public interface IUserService : IDatabaseItemService<User>
    {
        IUserRepository UserRepository { get; set; }
    }
}
