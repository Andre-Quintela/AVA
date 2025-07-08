using AVA.Application.DTOs;
using AVA.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVA.Application.Services
{
    public class UserService : IUserService
    {
        public Task AddUserAsync(UserDto user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetUserByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetUserByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserAsync(UserDto user)
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
