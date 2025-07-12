using AVA.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVA.Application.Interfaces
{
    public interface ILoginService
    {
        /// <summary>
        /// Validates the user credentials and returns a token if successful.
        /// </summary>
        /// <param name="loginDto">The login data transfer object containing user credentials.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating whether the validation was successful.</returns>
        Task<bool> ValidateUserAsync(LoginDto loginDto);
    }
}
