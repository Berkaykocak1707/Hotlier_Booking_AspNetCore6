using Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface IAuthService
    {
        IEnumerable<IdentityRole> GetRoles
        {
            get;
        }
        IEnumerable<IdentityUser> GetUsers();
        Task<IdentityResult> CreateUser(UserDtoForCreation userDto);
        Task<UserDtoForUpdate> GetOneUserForUpdate(string userName);
        Task<IdentityUser> GetOneUser(string userName);
        Task Update(UserDtoForUpdate dtoForUpdate);
        Task<IdentityResult> ResetPassword(ResetPasswordDto RpasswordDto);
        Task<IdentityResult> DeleteOneUser(string userName);
    }
}
