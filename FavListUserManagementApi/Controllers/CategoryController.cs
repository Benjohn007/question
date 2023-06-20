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
        public async Task<IActionResult> Create(CategoryDto catergory)
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
        [HttpGet]
        [Route("get-All-categories")]
        public async Task<IActionResult> Get()
        {
            try
            {
               var cat = await _service.GetAll();
                return Ok(cat);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update-category")]
        public async Task<IActionResult> Update(string categoryId, UpdateCategoryDto categoryDto)
        {
            try
            {
                var update = await _service.UpdateCategory(categoryId, categoryDto);
                return Ok(update);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete-category")]
        public async Task<IActionResult> Delete(string categoryId)
        {
            try
            {
                var cat = await _service.DeleteCategory(categoryId);
                return Ok(cat);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("get-category-by-id")]
        public async Task<IActionResult> GetById(string category)
        {
            try
            {
                return Ok(await _service.GetById(category));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
