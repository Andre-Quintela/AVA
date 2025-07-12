using AVA.Domain.Entities;
using AVA.Domain.Enums;
using AVA.Domain.Interfaces;
using AVA.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVA.Infrastructure.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly ApplicationDbContext _context;

        public LoginRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<User> ValidateUserAsync(User user)
        {
            var existingUser = _context.Users
                .FirstOrDefault(u => u.Email == user.Email);

            var validatedUser = new User
            {
                Id = existingUser?.Id ?? Guid.Empty,
                Name = existingUser?.Name,
                Email = existingUser?.Email,
                PasswordHash = existingUser?.PasswordHash,
                Role = existingUser?.Role != null ? (UserRole)existingUser.Role : UserRole.Aluno
            };

            return Task.FromResult(validatedUser);
        }
    }
}
