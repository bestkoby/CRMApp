using Microsoft.AspNetCore.Mvc;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Antra.CRMApp.WebMVC.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierServiceAsync supplierServiceAsync;
        private readonly IRegionServiceAsync regionServiceAsync;

        public SupplierController(ISupplierServiceAsync s, IRegionServiceAsync r)
        {
            supplierServiceAsync = s;
            regionServiceAsync = r;
        }
        public async Task<IActionResult> Index()
        {
            var collection = await supplierServiceAsync.GetAllAsync();
            if (collection != null)
                return View(collection);

            List<SupplierModel> model = new List<SupplierModel>();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var collection = await regionServiceAsync.GetAllAsync();
            ViewBag.Regions = new SelectList(collection, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SupplierModel model)
        {
            if (ModelState.IsValid)
            {
                await supplierServiceAsync.AddSupplierAsync(model);
                return RedirectToAction("Index");
            }
            var collection = await regionServiceAsync.GetAllAsync();
            ViewBag.Regions = new SelectList(collection, "Id", "Name");
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.IsEdit = false;
            var collection = await regionServiceAsync.GetAllAsync();
            ViewBag.Regions = new SelectList(collection, "Id", "Name");
            var empModel = await supplierServiceAsync.GetSupplierForEditAsync(id);
            return View(empModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SupplierModel model)
        {
            ViewBag.IsEdit = false;
            if (ModelState.IsValid)
            {
                await supplierServiceAsync.UpdateSupplierAsync(model);
                ViewBag.IsEdit = true;

            }
            var collection = await regionServiceAsync.GetAllAsync();
            ViewBag.Regions = new SelectList(collection, "Id", "Name");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await supplierServiceAsync.DeleteSupplierAsync(id);
            return RedirectToAction("Index");
        }
    }
}
