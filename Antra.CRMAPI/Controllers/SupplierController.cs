using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;

namespace Antra.CRMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierServiceAsync _supplierServiceAsync;

        public SupplierController(ISupplierServiceAsync s) { _supplierServiceAsync = s; }

        [HttpGet]
        public async Task<IActionResult> GET()
        {
            var res = await _supplierServiceAsync.GetAllAsync();
            if (res != null)
                return Ok(res);
            return NotFound();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GETById(int id)
        {
            var res = await _supplierServiceAsync.GetByIdAsync(id);
            if (res != null)
                return Ok(res);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post(SupplierModel model)
        {
            var res = await _supplierServiceAsync.AddSupplierAsync(model);
            if (res > 0)
                return Ok(res);
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> PUT(SupplierModel model)
        {
            var res = await  _supplierServiceAsync.UpdateSupplierAsync(model);
            if (res > 0)
                return Ok(res);
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DELETE(int id)
        {
            var res = await _supplierServiceAsync.DeleteSupplierAsync(id);
            if (res > 0)
                return Ok("Deleted");
            return BadRequest(res);
        }
    }
}
