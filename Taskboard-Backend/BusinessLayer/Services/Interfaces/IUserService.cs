using DomainModels.Models;
using RepositoryLayer.Repository;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Interfaces
{
    public interface IUserService : IDatabaseItemService<User>
    {
        IUserRepository UserRepository { get; set; }

        Task<User> Get(string email);

        Task<bool> Exists(string email);

        Task<User> Register(User user, string password);

        Task<User> Login(string email, string password);

        Task<User> EditUser(User user, string oldPassword = null, string newPassword = null);
    }
}
