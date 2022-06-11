using Microsoft.AspNetCore.Mvc;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Antra.CRMApp.WebMVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerServiceAsync customerServiceAsync;
        private readonly IRegionServiceAsync regionServiceAsync;
   
        public CustomerController(ICustomerServiceAsync  c, IRegionServiceAsync r)
        {
            customerServiceAsync = c;
            regionServiceAsync = r;
        }
        public async Task<IActionResult> Index()
        {
            var collection = await customerServiceAsync.GetAllAsync();
            var region_collection = await regionServiceAsync.GetAllAsync();
            ViewBag.Regions = new SelectList(region_collection, "Id", "Name"); 
            if (collection != null)
                return View(collection);

            List<CustomerResponseModel> model = new List<CustomerResponseModel>();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var region_collection = await regionServiceAsync.GetAllAsync();
            ViewBag.Regions = new SelectList(region_collection, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await customerServiceAsync.AddCustomerAsync(model); 
                return RedirectToAction("Index");
            }
            var region_collection = await regionServiceAsync.GetAllAsync();
            ViewBag.Regions = new SelectList(region_collection, "Id", "Name");
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.IsEdit = false;
            var empModel = await customerServiceAsync.GetCustomerForEditAsync(id);
            var region_collection = await regionServiceAsync.GetAllAsync();
            ViewBag.Regions = new SelectList(region_collection, "Id", "Name");
            return View(empModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CustomerRequestModel model)
        {
            ViewBag.IsEdit = false; 
            if (ModelState.IsValid)
            {
                await customerServiceAsync.UpdateCustomerAsync(model);
                var region_collection = await regionServiceAsync.GetAllAsync();
                ViewBag.Regions = new SelectList(region_collection, "Id", "Name");
                ViewBag.IsEdit = true;

            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await customerServiceAsync.DeleteCustomerAsync(id);
            return RedirectToAction("Index");
        }
    }
}
