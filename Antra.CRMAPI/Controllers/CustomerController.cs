using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;

namespace Antra.CRMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly  ICustomerServiceAsync _customerService;

        public CustomerController(ICustomerServiceAsync c) { _customerService = c; }

        [HttpGet]
        public async Task<IActionResult> GET()
        {
            var res = await _customerService.GetAllAsync();
            if(res!=null)
                return Ok(res);
            return NotFound();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GETById(int id)
        {
            var res = await _customerService.GetByIdAsync(id);
            if (res != null)
                return Ok(res);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post(CustomerRequestModel model)
        {
            var res = await _customerService.AddCustomerAsync(model);
            if (res > 0)
                return Ok(res);
            return BadRequest( );
        }

        [HttpPut] 
        public async Task<IActionResult> PUT(CustomerRequestModel model)
        {
            var res = await _customerService.UpdateCustomerAsync(model);
            if (res > 0)
                return Ok(res);
            return BadRequest( );
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DELETE(int id)
        {
            var res = await _customerService.DeleteCustomerAsync(id);
            if (res > 0)
                return Ok("Deleted");
            return BadRequest(res);
        }

    }
}
