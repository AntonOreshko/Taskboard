using BusinessLayer.Services.Interfaces;
using DomainModels.Models;
using RepositoryLayer.Repository;

namespace BusinessLayer.Services
{
    public class UserService : DatabaseItemService<User>, IUserService
    {
        public IUserRepository UserRepository { get; set; }

        public UserService(IRepository<User> repo, IUserRepository customRepo): base(repo)
        {
            UserRepository = customRepo;
        }
    }
}
