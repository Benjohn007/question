using FavListUserManagement.Application.IServices;
using FavListUserManagement.Domain.Entities;
using FavListUserManagement.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FavListUserManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateAccountController : ControllerBase
    {
        private readonly ICreateAccountService _createAccountService;
        private readonly IUnitOfWork _unitOfWork;

        public CreateAccountController(ICreateAccountService createAccountService, IUnitOfWork unitOfWork)
        {
            _createAccountService = createAccountService;
            _unitOfWork = unitOfWork;
        }
        //[HttpGet]
        //public async Task<IActionResult> CreateAccount(SignUp signUp)
        //{
        //    var user = await _createAccountService.SignUpAsync(signUp);
        //    if (user == null)
        //    {
        //        return BadRequest("invalid input");
        //    }
        //}
    }
}
