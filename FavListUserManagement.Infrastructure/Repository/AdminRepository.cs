using FavListUserManagement.Domain.DTO;
using FavListUserManagement.Domain.Entities;
using FavListUserManagement.Domain.IRepository;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavListUserManagement.Infrastructure.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;

        public AdminRepository(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        /* LIST OF EENDPOINT STILL TO BE CREATED
         * GET-ALL-USER
         * GET-USER-BY-ID
         * UPDATE-USER
         * DELETE-USER
         */

        public async Task<bool> CreateRole(RoleDto role)
        {
            try
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = role.RoleName.ToString(),
                };
                var result = await _roleManager.CreateAsync(identityRole);


                return result.Succeeded;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public async Task<bool> AddUserRole(string userId, UserRole role)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);

                if (user == null) return false;

                var result = await _userManager.AddToRoleAsync(user, role.ToString());

                return result.Succeeded;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public async Task<bool> RemoveUserRole(string userId, UserRole role)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);

                if (user == null) return false;

                var result = await _userManager.RemoveFromRoleAsync(user, role.ToString());

                return result.Succeeded;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
           
        }

        public async Task<bool> RemoveUserById(string userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if(user == null) return false;
                 var result = await _userManager.DeleteAsync(user);
                return result.Succeeded;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> GetUserById(string userId)
        {
            try
            {
               var user = await _userManager.FindByIdAsync(userId);
                if (user == null) return false;

                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }

}
