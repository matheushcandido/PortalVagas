using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RepositoriesInterfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmail(string email);
        Task AddUser(User user);
        Task<User> ValidateUser(string email, string password);
    }
}
