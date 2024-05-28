
using Core.Entities;
using Core.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ConfigureDatabase _context;

        public UserRepository(ConfigureDatabase context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> ValidateUser(string email, string password)
        {
            var user = await GetUserByEmail(email);
            if (user != null && user.Password == password)
            {
                return user;
            }
            return null;
        }
    }
}
