using FavListUserManagement.Application.IServices;
using FavListUserManagement.Domain.DTO;
using FavListUserManagement.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FavListUserManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICatergoryService _service;

        public CategoryController(ICatergoryService service)
        {
            _service = service;
        }
        [HttpPost]
        [Route("create-category")]
        public async Task<IActionResult> Create(CatergoryDto catergory)
        {
            try
            {
                var result = await _service.Create(catergory);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
