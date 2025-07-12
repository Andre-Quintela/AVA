using AVA.Application.DTOs;
using AVA.Application.Interfaces;
using AVA.Application.Interfaces.Security;
using AVA.Domain.Entities;
using AVA.Domain.Interfaces;

namespace AVA.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public Task CreateUserAsync(UserDto userDto)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = userDto.Email,
                Name = userDto.Name,
                PasswordHash = _passwordHasher.HashPassword(userDto.Password),
                Role = userDto.Role
            };

            return _userRepository.CreateUserAsync(user);
        }

        public Task DeleteUserAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            if (user == null)
            {
                return null;
            }

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Password = user.PasswordHash,
                Role = user.Role
            };
        }

        public Task<UserDto> GetUserByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserAsync(UserDto userDto)
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
