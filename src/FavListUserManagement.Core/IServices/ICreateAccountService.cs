using FavListUserManagement.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavListUserManagement.Application.IServices
{
    public interface ICreateAccountService
    {
        Task<IdentityResult> SignUpAsync(SignUp signUp);
    }
}
