using FavListUserManagement.Application.IServices;
using FavListUserManagement.Domain.DTO;
using FavListUserManagement.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "SuperAdmin")]
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
        //[HttpGet("Get-all-User")]
        //public async Task<IActionResult> GetAllUser()
        //{
        //    try
        //    {
        //        return Ok(await _adminService.GetAll());
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        [HttpGet("Get-User-By-Id")]
        public async Task<IActionResult> GetUserById(string userId)
        {
            try
            {
                var user = await _adminService.GetUserById(userId);
                if (user.Succeeded) return Ok(user);
                return BadRequest(user);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        [HttpPut("Update-User")]
        public async Task<IActionResult> UpdateUser(string userId, [FromBody] User update)
        {
            try
            {
                var user = await _adminService.GetUserById(userId);
                if (user == null)
                {
                    //log error
                    ModelState.AddModelError("ErrorMessage", "Amenity ID is Invalid");
                    return BadRequest(ModelState);
                }
                var updateUser = await _adminService.UpdateUser(userId, update);
                return Ok(updateUser);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("Remove-User")]
        public async Task<IActionResult> RemoveUser(string userId)
        {
            try
            {
                var user = await _adminService.RemoveUser(userId);
                if (user.Succeeded) return Ok(user);
                return BadRequest(user);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
