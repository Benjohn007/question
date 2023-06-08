using FavListUserManagement.Application.IServices;
using FavListUserManagement.Domain.Entities;
using FavListUserManagement.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Identity;

namespace FavListUserManagement.Application.Services
{
    public class CreateAccountService : ICreateAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;

        public CreateAccountService(UserManager<User> userManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<IdentityResult> SignUpAsync(SignUp signUp)
        {
            try
            {
                var user = new User
                {
                    FirstName = signUp.Firstname,
                    LastName = signUp.Lastname,
                    Email = signUp.Email,
                    UserName = signUp.Email

                };
                var result = await _userManager.CreateAsync(user, signUp.Password);
                //await _unitOfWork.SignUpRepository.Add(user);

                return result;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
          
        }
    }
}
