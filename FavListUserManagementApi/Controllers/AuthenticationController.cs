using FavListUserManagement.Application.IServices;
using FavListUserManagement.Domain.DTO;
using FavListUserManagement.Domain.Entities;
using FavListUserManagement.Infrastructure.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FavListUserManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly UserManager<User> _userManager;
        private readonly IEmailServices _emailServices;

        public AuthenticationController(IAuthenticationService authenticationService, UserManager<User> userManager, IEmailServices emailServices)
        {
            _authenticationService = authenticationService;
            _userManager = userManager;
            _emailServices = emailServices;
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

        [HttpPost]
        [AllowAnonymous]
        [Route("forget-password")]

        public async Task<IActionResult> ForgotPassword([Required] string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var forgetPasswordLink = Url.Action(nameof(ResetPassword), "Authentication", new { token, email = user.Email }, Request.Scheme);
                var message = new Message(new List<string> { user.Email! }, "Reset Password link", forgetPasswordLink!);
                _emailServices.SendEmail(message);

                return StatusCode(StatusCodes.Status200OK,
                       new Response { Status = "Success", Mesaage = $"Password change request has been sent to your email {user.Email}. please open your email and clink the link" });
            }
            return StatusCode(StatusCodes.Status404NotFound,
                       new Response { Status = "Error", Mesaage = $"Could not send link to email. please try again" });
        }

        [HttpGet("reset-password")]
        public IActionResult ResetPassword(string token, string email)
        {
            var model = new ResetPassword { Token = token, Email = email };

            return Ok(new { model });

        }
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPassword model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                var resetPassResult = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
                if (!resetPassResult.Succeeded)
                {
                    foreach (var error in resetPassResult.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return Ok(ModelState);
                }
                return StatusCode(StatusCodes.Status200OK,
                       new Response { Status = "Success", Mesaage = $"Password has been changed" });
            }
            return StatusCode(StatusCodes.Status400BadRequest,
                   new Response { Status = "Error", Mesaage = "Could not send link to email, please try again" });
        }

    }
}

