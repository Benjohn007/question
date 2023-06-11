using FavListUserManagement.Domain.DTO;
using FavListUserManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavListUserManagement.Application.IServices
{
    public interface IAuthenticationService
    {
        Task<Response<string>> Login(LoginDto model);
        Task<Response<string>> RefreshToken();
        Task<Response<string>> Register(RegisterDto user);
    }
}
