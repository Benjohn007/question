using FavListUserManagement.Application.IServices;
using FavListUserManagement.Domain.DTO;
using FavListUserManagement.Domain.Entities;
using FavListUserManagement.Domain.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Org.BouncyCastle.Asn1.Ocsp;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Security.Policy;

namespace FavListUserManagement.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepositotry repository;

        public AuthenticationService(IAuthenticationRepositotry repository)
        {
            this.repository = repository;
        }

        public async Task<Response<string>> Login(LoginDto model)
        {
            try
            {
                return await repository.Login(model);

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
                return await repository.RefreshToken();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Response<string>> Register(RegisterDto user)
        {
            try
            {
                var result = await repository.Register(user);
                var response = new Response<string>();
                if (result)
                {
                    response.Succeeded = true;
                    response.StatusCode = (int)HttpStatusCode.Created;
                    response.Message = "Successfully registered";
                }
                else
                {
                    response.Succeeded = false;
                    response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                    response.Message = "Failed to register, please change check the email, username and password.";
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }


    }

}
