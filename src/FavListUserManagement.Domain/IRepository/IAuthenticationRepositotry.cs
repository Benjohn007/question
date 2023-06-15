using FavListUserManagement.Domain.DTO;
using FavListUserManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavListUserManagement.Domain.IRepository
{
    public interface IAuthenticationRepositotry
    {
        Task<Response<string>> Login(LoginDto model);
        Task<bool> Register(RegisterDto user);
        Task<Response<string>> RefreshToken();
    }
}
