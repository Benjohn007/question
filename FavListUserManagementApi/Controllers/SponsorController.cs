using FavListUserManagement.Application.IServices;
using FavListUserManagement.Domain.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FavListUserManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SponsorController : ControllerBase
    {
        private readonly ISponsorService _sponsorService;

        public SponsorController(ISponsorService sponsorService)
        {
            _sponsorService = sponsorService;
        }
        [HttpPost]
        [Route("create-sponsor")]
        public async Task<IActionResult> Create(SponsorDto sponsor)
        {
            try
            {
                var result = await _sponsorService.Create(sponsor);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("get-All-sponsors")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var cat = await _sponsorService.GetAll();
                return Ok(cat);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("get-sponsor-by-id")]
        public async Task<IActionResult> GetById(string category)
        {
            try
            {
                return Ok(await _sponsorService.GetById(category));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete-sponsor-by-Id")]
        public async Task<IActionResult> Delete(string categoryId)
        {
            try
            {
                var cat = await _sponsorService.DeleteCategory(categoryId);
                return Ok(cat);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        [Route("update-sponsor")]
        public async Task<IActionResult> Update(string categoryId, SponsorDto sponsorDto)
        {
            try
            {
                var update = await _sponsorService.UpdateCategory(categoryId, sponsorDto);
                return Ok(update);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
