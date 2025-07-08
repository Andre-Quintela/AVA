using AVA.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVA.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserByIdAsync(Guid id);
        Task<UserDto> GetUserByEmailAsync(string email);
        Task AddUserAsync(UserDto user);
        Task UpdateUserAsync(UserDto user);
        Task DeleteUserAsync(Guid id);
        Task<bool> UserExistsAsync(Guid id);
        Task<bool> UserExistsByEmailAsync(string email);

    }
}
