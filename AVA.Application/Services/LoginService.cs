using AVA.Application.DTOs;
using AVA.Application.Interfaces;
using AVA.Application.Interfaces.Security;
using AVA.Domain.Entities;
using AVA.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVA.Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IPasswordHasher _passwordHasher;

        public LoginService(ILoginRepository loginRepository, IPasswordHasher passwordHasher)
        {
            _loginRepository = loginRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<bool> ValidateUserAsync(LoginDto loginDto)
        {
            var loginUser = new User
            {
                Email = loginDto.Email,
                PasswordHash = _passwordHasher.HashPassword(loginDto.Password)
            };
            var storedUser = await _loginRepository.ValidateUserAsync(loginUser);

            if (storedUser?.PasswordHash == null)
            {
                return false;
            }

            return _passwordHasher.VerifyPassword(storedUser.PasswordHash, loginDto.Password);
        }
    }
}
