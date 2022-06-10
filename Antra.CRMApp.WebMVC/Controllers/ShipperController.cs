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
    }
}
