using System.Collections.Generic;
using DomainModels.Models;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository
{
    public interface IUserRepository: IRepository<User>
    {
        Task<User> GetAsync(string email);

        Task<bool> ContainsAsync(string email);

        Task<IEnumerable<User>> GetUsersIn(IEnumerable<long> ids);

        Task<IEnumerable<User>> SearchUsers(string filter);

        Task<IEnumerable<User>> SearchUsersIn(string filter, IEnumerable<long> ids);
    }
}
