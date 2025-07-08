using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVA.Domain.Enums
{
    public class UserRoleEnum
    {
        public enum UserRole
        {
            Admin = 1,
            Professor = 2,
            Aluno = 3
        }
        public static string GetRoleName(UserRole role)
        {
            return role switch
            {
                UserRole.Admin => "Administrator",
                UserRole.Professor => "Professor",
                UserRole.Aluno => "Aluno",
                _ => "Unknown Role"
            };
        }
    }
}
