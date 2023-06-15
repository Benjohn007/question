using FavListUserManagement.Domain.DTO;
using FavListUserManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavListUserManagement.Domain.IRepository
{
    public interface IAdminRepository
    {      
        Task<bool> CreateRole(RoleDto role);
        Task<bool> AddUserRole(string userId, UserRole role);
        Task<bool> RemoveUserRole(string userId, UserRole role);
        Task<bool> RemoveUserById(string userId);
        Task<bool> GetUserById(string userId);
    }
}
