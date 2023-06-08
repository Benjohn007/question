using FavListUserManagement.Application;
using FavListUserManagement.Application.Utilities;
using FavListUserManagement.Domain.DTO;
using FavListUserManagement.Domain.Entities;
using FavListUserManagement.Domain.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace FavListUserManagement.Infrastructure.Repository
{
    public class AuthenticationRepository : IAuthenticationRepositotry
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _token;
        private readonly ITokenDetails _tokenDetails;
        private readonly IHttpContextAccessor _httpContext;

        public AuthenticationRepository(UserManager<User> userManager, ITokenService token, ITokenDetails tokenDetails, IHttpContextAccessor httpContext)
        {
            _userManager = userManager;
            _token = token;
            _tokenDetails = tokenDetails;
            _httpContext = httpContext;
        }

        public async Task<Response<string>> Login(LoginDto model)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(model.Username);
                var response = new Response<string>();
                if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    var userRoles = await _userManager.GetRolesAsync(user);

                    var UserModel = new UserModel
                    {
                        Id = user.Id,
                        UserName = model.Username,
                        Role = userRoles.FirstOrDefault() ?? ""
                    };


                    var refreshToken = _token.SetRefreshToken();
                    //var refreshToken = SetRefreshToken();
                    await SaveRefreshToken(user, refreshToken);
                    response.Succeeded = true;
                    response.Data = _token.CreateToken(UserModel);
                    response.StatusCode = (int)HttpStatusCode.Accepted;
                    response.Message = "Logged in successfully";
                }
                else
                {
                    response.Succeeded = false;
                    response.Message = "Wrong Credential";

                    response.StatusCode = (int)HttpStatusCode.Unauthorized;
                }
                return response;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            
        }


        private async Task SaveRefreshToken(User user, RefreshToken refreshToken)
        {
            try
            {
                user.Refreshtoken = refreshToken.Refreshtoken;
                user.RefreshTokenExpiryTime = refreshToken.RefreshTokenExpiryTime;
                await _userManager.UpdateAsync(user);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
           
        }

        public async Task<Response<string>> RefreshToken()
        {
            try
            {
                var currentToken = _httpContext.HttpContext.Request.Cookies["refresh-token"];
                var user = await _userManager.FindByIdAsync(_tokenDetails.GetId());

                var response = new Response<string>();
                response.Succeeded = false;
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                if (user == null || user.Refreshtoken != currentToken)
                {
                    response.Data = "Invalid refresh token";
                }
                else if (user.RefreshTokenExpiryTime < DateTime.Now)
                {
                    response.Message = "Token Expired";
                }
                else
                {
                    var UserModel = new UserModel
                    {
                        Id = _tokenDetails.GetId(),
                        UserName = _tokenDetails.GetUserName(),
                        Role = _tokenDetails.GetRoles()
                    };

                    response.Succeeded = true;
                    response.Data = _token.CreateToken(UserModel);
                    response.Message = "Successful refreshed token";
                    response.StatusCode = (int)HttpStatusCode.Accepted;

                    var refreshToken = _token.SetRefreshToken();
                    await SaveRefreshToken(user, refreshToken);
                }
                return response;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<bool> Register(RegisterDto user)
        {
            try
            {
                var mapInitializer = new MapInitializer();
                var newUser = mapInitializer.regMapper.Map<RegisterDto, User>(user);

                var result = await _userManager.CreateAsync(newUser, user.Password);

                if (result.Succeeded) await _userManager.AddToRoleAsync(newUser, "AppUser");

                return result.Succeeded;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            
        }
    }
}
