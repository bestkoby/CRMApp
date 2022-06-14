using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;

namespace Antra.CRMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRegionServiceAsync _regionService;

        public RegionController(IRegionServiceAsync r) { _regionService = r; }

        [HttpGet]
        public async Task<IActionResult> GET()
        {
            var res = await _regionService.GetAllAsync();
            if (res != null)
                return Ok(res);
            return NotFound();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GETById(int id)
        {
            var res = await _regionService.GetByIdAsync(id);
            if (res != null)
                return Ok(res);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post(RegionModel model)
        {
            var res = await _regionService.AddRegionAsync(model);
            if (res > 0)
                return Ok(res);
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> PUT(RegionModel model)
        {
            var res = await _regionService.UpdateRegionAsync(model);
            if (res > 0)
                return Ok(res);
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DELETE(int id)
        {
            var res = await _regionService.DeleteRegionAsync(id);
            if (res > 0)
                return Ok("Deleted");
            return BadRequest(res);
        }
    }
}
