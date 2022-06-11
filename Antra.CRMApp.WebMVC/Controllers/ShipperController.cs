using Microsoft.AspNetCore.Mvc;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;

namespace Antra.CRMApp.WebMVC.Controllers
{
    public class ShipperController : Controller
    {
        private readonly IShipperServiceAsync _shipperServiceAsync;

        public ShipperController(IShipperServiceAsync _s)
        {
            _shipperServiceAsync = _s;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _shipperServiceAsync.GetAllAsync();
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ShipperRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await _shipperServiceAsync.AddShipperAsync(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.IsEdit = false;
            var empModel = await _shipperServiceAsync.GetShipperForEditAsync(id);
            return View(empModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ShipperRequestModel model)
        {
            ViewBag.IsEdit = false;
            if (ModelState.IsValid)
            {
                await _shipperServiceAsync.UpdateShipperAsync(model);
                ViewBag.IsEdit = true;
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _shipperServiceAsync.DeleteShipperAsync(id);
            return RedirectToAction("Index");
        }
    }
}
