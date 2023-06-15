using FavListUserManagement.Domain.DTO;
using FavListUserManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavListUserManagement.Application.IServices
{
    public interface IAdminService
    {
        Task<Response<string>> AddUserRole(string userId, UserRole role);
        Task<Response<string>> CreateRole(RoleDto role);
        Task<Response<string>> RemoveUserRole(string userId, UserRole role);
        Task<Response<User>> GetUserById(string userId);
        Task<Response<User>> RemoveUser(string userId);
        Task<Response<User>> UpdateUser(string userId, User updateDto);
        //Task<Response<User>> GetAll();
    }
}
