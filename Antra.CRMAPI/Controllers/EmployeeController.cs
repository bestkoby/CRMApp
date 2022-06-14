using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc; 
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;

namespace Antra.CRMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeServiceAsync employeeServiceAsync;

        public EmployeeController(IEmployeeServiceAsync employeeServiceAsync)
        {
            this.employeeServiceAsync = employeeServiceAsync;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var employees = await employeeServiceAsync.GetAllAsync();
            if(employees != null)
                return Ok(employees);
            return NotFound();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await employeeServiceAsync.GetAllAsync();
            if (employee != null)
                return Ok(employee);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post(EmployeeRequestModel model)
        {
            var res = await employeeServiceAsync.AddEmployeeAsync(model);
            if (res >0)
                return Ok(model);
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(EmployeeRequestModel model)
        {
            var res = await employeeServiceAsync.UpdateEmployeeAsync(model);
            if (res > 0)
                return Ok(model);
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await employeeServiceAsync.DeleteEmployeeAsync(id);
            if (res > 0)
                return Ok("Deleted");
            return BadRequest();
        }
    }
}
