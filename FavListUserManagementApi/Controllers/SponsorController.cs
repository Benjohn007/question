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
    }
}
