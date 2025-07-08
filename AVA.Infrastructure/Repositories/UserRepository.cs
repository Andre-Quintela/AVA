using AVA.Domain.Entities;
using AVA.Domain.Interfaces;

namespace AVA.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task AddUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserExistsAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserExistsByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}
