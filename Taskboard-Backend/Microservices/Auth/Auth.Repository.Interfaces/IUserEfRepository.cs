using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth.DomainModels.Models;
using Common.Repository.Interfaces;

namespace Auth.Repository.Interfaces
{
    public interface IUserEfRepository : IEfRepository<User>
    {
        Task<User> GetAsync(string email);

        Task<bool> ContainsAsync(string email);

        Task<IEnumerable<User>> GetUsersIn(IEnumerable<Guid> ids);

        Task<IEnumerable<User>> SearchUsers(string filter);

        Task<IEnumerable<User>> SearchUsersIn(string filter, IEnumerable<Guid> ids);
    }
}