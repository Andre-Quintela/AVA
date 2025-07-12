using AVA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVA.Domain.Interfaces
{
    public interface ILoginRepository
    {
        Task<User> ValidateUserAsync(User user);
    }
}
