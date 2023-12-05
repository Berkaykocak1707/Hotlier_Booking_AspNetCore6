using AutoMapper;
using Business.Contracts;
using Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class AuthManager : IAuthService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;
        public AuthManager(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
        }
        public IEnumerable<IdentityRole> GetRoles => _roleManager.Roles.ToList();

        public async Task<IdentityResult> CreateUser(UserDtoForCreation userDto)
        {
            var user = _mapper.Map<IdentityUser>(userDto);
            var result = await _userManager.CreateAsync(user, userDto.Password);

            if (!result.Succeeded)
            {
                throw new Exception("Problem User");
            }
            if (userDto.Roles.Count > 0)
            {
                var roleResult = await _userManager.AddToRolesAsync(user, userDto.Roles);
                if (!roleResult.Succeeded)
                {
                    throw new Exception("Problem Role");
                }
            }
            return result;
        }

        public async Task<IdentityResult> DeleteOneUser(string userName)
        {
            var user = await GetOneUser(userName);
            if (user is not null)
                return await _userManager.DeleteAsync(user);
            throw new Exception("User not found");
        }

        public async Task<IdentityUser> GetOneUser(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user is not null)
                return user;
            throw new Exception("User bulunamadı");
        }

        public async Task<UserDtoForUpdate> GetOneUserForUpdate(string userName)
        {
            var user = await GetOneUser(userName);
            if (user is not null)
            {
                var userDto = _mapper.Map<UserDtoForUpdate>(user);
                userDto.Roles = new HashSet<string>(GetRoles.Select(r => r.Name).ToList());
                userDto.UserRoles = new HashSet<string>(await _userManager.GetRolesAsync(user));
                return userDto;
            }
            throw new Exception("GetOneUserForUpdate Error!");
        }

        public IEnumerable<IdentityUser> GetUsers()
        {
            return _userManager.Users.ToList();
        }

        public async Task<IdentityResult> ResetPassword(ResetPasswordDto RpasswordDto)
        {
            var user = await GetOneUser(RpasswordDto.Username);
            if (user is not null)
            {
                await _userManager.RemovePasswordAsync(user);
                var result = await _userManager.AddPasswordAsync(user, RpasswordDto.Password);
                return result;
            }
            throw new Exception("Reset Error!");
        }

        public async Task Update(UserDtoForUpdate dtoForUpdate)
        {
            var user = await GetOneUser(dtoForUpdate.UserName);
            user.PhoneNumber = dtoForUpdate.PhoneNumber;
            user.UserName = dtoForUpdate.UserName;
            user.Email = dtoForUpdate.Email;
            if (user is not null)
            {
                var result = await _userManager.UpdateAsync(user);
                if (dtoForUpdate.Roles.Count > 0)
                {
                    var userRoles = await _userManager.GetRolesAsync(user);
                    var r1 = await _userManager.RemoveFromRolesAsync(user, userRoles);
                    var r2 = await _userManager.AddToRolesAsync(user, dtoForUpdate.Roles);
                }
                return;
            }
            throw new Exception("Update Error!");
        }
    }
}
