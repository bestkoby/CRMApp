using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;

namespace Antra.CRMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        private readonly IShipperServiceAsync shipperServiceAsync;

        public ShipperController(IShipperServiceAsync s) { shipperServiceAsync = s; }

        [HttpGet]
        public async Task<IActionResult> GET()
        {
            var res = await shipperServiceAsync.GetAllAsync();
            if (res != null)
                return Ok(res);
            return NotFound();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GETById(int id)
        {
            var res = await shipperServiceAsync.GetByIdAsync(id);
            if (res != null)
                return Ok(res);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post(ShipperRequestModel model)
        {
            var res = await shipperServiceAsync.AddShipperAsync(model);
            if (res > 0)
                return Ok(res);
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> PUT(ShipperRequestModel model)
        {
            var res = await shipperServiceAsync.UpdateShipperAsync(model);
            if (res > 0)
                return Ok(res);
            return BadRequest();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DELETE(int id)
        {
            var res = await shipperServiceAsync.DeleteShipperAsync(id);
            if (res > 0)
                return Ok("Deleted");
            return BadRequest(res);
        }
    }
}
