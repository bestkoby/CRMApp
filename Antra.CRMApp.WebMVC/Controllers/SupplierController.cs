using Microsoft.AspNetCore.Mvc;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
namespace Antra.CRMApp.WebMVC.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierServiceAsync supplierServiceAsync;

        public SupplierController(ISupplierServiceAsync s)
        {
            supplierServiceAsync = s;
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
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.IsEdit = false;
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
