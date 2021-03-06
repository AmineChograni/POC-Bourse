using AuthenticationServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationServer.Services.UserRepositories
{
    public interface IUserRepository
    {
        Task<User> GetByEmail(string email);

        Task<User> GetByUsername(string username);

        Task<User> Create(User user);
    }
}
