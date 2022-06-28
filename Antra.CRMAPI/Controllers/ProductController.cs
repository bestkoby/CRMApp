using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;

namespace Antra.CRMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServiceAsync _productServiceAsync;

        public ProductController(IProductServiceAsync p) { _productServiceAsync = p; }

        [HttpGet]
        public async Task<IActionResult> GET()
        {
            var res = await _productServiceAsync.GetAllAsync();
            if (res != null)
                return Ok(res);
            return NotFound();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GETById(int id)
        {
            var res = await _productServiceAsync.GetByIdAsync(id);
            if (res != null)
                return Ok(res);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductRequestModel model)
        {
            var res = await _productServiceAsync.AddProductAsync(model);
            if (res > 0)
                return Ok(res);
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> PUT(ProductRequestModel model)
        {
            var res = await _productServiceAsync.UpdateProductAsync(model);
            if (res > 0)
                return Ok(res);
            return BadRequest();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DELETE(int id)
        {
            var res = await _productServiceAsync.DeleteProductAsync(id);
            if (res > 0)
                return Ok("Deleted");
            return BadRequest(res);
        }
    }
}
