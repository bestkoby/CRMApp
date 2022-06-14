using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;

namespace Antra.CRMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServiceAsync categoryServiceAsync;

        public CategoryController(ICategoryServiceAsync c) { categoryServiceAsync = c; }

        [HttpGet]
        public async Task<IActionResult> GET()
        {
            var res = await categoryServiceAsync.GetAllAsync();
            if (res != null)
                return Ok(res);
            return NotFound();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GETById(int id)
        {
            var res = await categoryServiceAsync.GetByIdAsync(id);
            if (res != null)
                return Ok(res);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post(CategoryRequestModel model)
        {
            var res = await categoryServiceAsync.AddCategoryAsync(model);
            if (res > 0)
                return Ok(res);
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> PUT(CategoryRequestModel model)
        {
            var res = await categoryServiceAsync.UpdateCategoryAsync(model);
            if (res > 0)
                return Ok(res);
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DELETE(int id)
        {
            var res = await categoryServiceAsync.DeleteCategoryAsync(id);
            if (res > 0)
                return Ok("Deleted");
            return BadRequest(res);
        }
    }
}
