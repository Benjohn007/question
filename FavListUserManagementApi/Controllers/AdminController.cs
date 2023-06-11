using FavListUserManagement.Application.IServices;
using FavListUserManagement.Domain.DTO;
using FavListUserManagement.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FavListUserManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost("Create-role")]
        public async Task<IActionResult> CreateRole(RoleDto role)
        {
            try
            {
                var response = await _adminService.CreateRole(role);
                if (response.Succeeded) return Ok(response);
                return BadRequest(response);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
           
        }

        [HttpPost("Add-user-role/{userId}")]
        public async Task<IActionResult> AddUserRole(string userId, UserRole roles)
        {
            try
            {
                var response = await _adminService.AddUserRole(userId, roles);
                if (response.Succeeded) return Ok(response);
                return BadRequest(response);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
         
        }

        [HttpPost("Remove-user-role/{userId}")]
        public async Task<IActionResult> RemoveUserRole(string userId, UserRole roles)
        {
            try
            {
                var response = await _adminService.RemoveUserRole(userId, roles);
                if (response.Succeeded) return Ok(response);
                return BadRequest(response);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        
        }
    }
}
