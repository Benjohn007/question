using FavListUserManagement.Application.IServices;
using FavListUserManagement.Domain.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FavListUserManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto user)
        {
            try
            {
                var register = await _authenticationService.Register(user);
                if (register.Succeeded == true) return Ok(register);
                return BadRequest(register);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
         
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            try
            {
                var login = await _authenticationService.Login(model);
                if (login.Succeeded == false) return Unauthorized(login);
                return Ok(login);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
          
        }
        [HttpGet("Refresh-Token")]
        public async Task<IActionResult> RefreshToken()
        {
            try
            {
                var token = await _authenticationService.RefreshToken();
                if (token.Succeeded == false) return BadRequest(token);
                return Ok(token);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
          
        }
    }
}

