using Microsoft.AspNetCore.Mvc;
using Antra.CRMApp.WebMVC.Models;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace Antra.CRMApp.WebMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServiceAsync productServiceAsync;
        private readonly ICategoryServiceAsync categoryServiceAsync;
        private readonly ISupplierServiceAsync supplierServiceAsync;

        public ProductController(IProductServiceAsync productservice, ICategoryServiceAsync cat, ISupplierServiceAsync sup)
        {
            productServiceAsync = productservice;
            categoryServiceAsync = cat;
            supplierServiceAsync = sup;
        }
        public async Task<IActionResult> Index()
        {
            var empCollection = await productServiceAsync.GetAllAsync();
            if (empCollection != null)
                return View(empCollection);

            List<ProductResponseModel> model = new List<ProductResponseModel>();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var collections = await supplierServiceAsync.GetAllAsync();
            var collectionc = await categoryServiceAsync.GetAllAsync();
            ViewBag.Supplier = new SelectList(collections, "Id", "Name");
            ViewBag.Category = new SelectList(collectionc, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await productServiceAsync.AddProductAsync(model);
                return RedirectToAction("Index");
            }
            var collections = await supplierServiceAsync.GetAllAsync();
            var collectionc = await categoryServiceAsync.GetAllAsync();
            ViewBag.Supplier = new SelectList(collections, "Id", "Name");
            ViewBag.Category = new SelectList(collectionc, "Id", "Name");
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.IsEdit = false;
            var proModel = await productServiceAsync.GetProductForEditAsync(id); 
            var collections = await supplierServiceAsync.GetAllAsync();
            var collectionc = await categoryServiceAsync.GetAllAsync();
            ViewBag.Supplier = new SelectList(collections, "Id", "Name");
            ViewBag.Category = new SelectList(collectionc, "Id", "Name");
            return View(proModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductRequestModel model)
        {
            ViewBag.IsEdit = false;
            var collections = await supplierServiceAsync.GetAllAsync();
            var collectionc = await categoryServiceAsync.GetAllAsync();
            ViewBag.Supplier = new SelectList(collections, "Id", "Name");
            ViewBag.Category = new SelectList(collectionc, "Id", "Name");
            if (ModelState.IsValid)
            {
                await productServiceAsync.UpdateProductAsync(model);
                ViewBag.IsEdit = true;

            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await productServiceAsync.DeleteProductAsync(id);
            return RedirectToAction("Index");
        }






        //public IActionResult Index()
        //{
        //    List<Product> products = new List<Product>();
        //    products.Add(new Product() { Id=1, Name="Laptop", Color="Silver", Price=2000});
        //    products.Add(new Product() { Id = 2, Name = "Iphone", Color = "Black", Price = 1000 });
        //    products.Add(new Product() { Id = 3, Name = "Samsung Galaxy", Color = "Blue", Price = 900 });
        //    products.Add(new Product() { Id = 4, Name = "Chair", Color = "Wooden", Price = 120 });
        //    products.Add(new Product() { Id = 5, Name = "Table", Color = "White", Price = 250 });

        //    ViewData["Title"] = "Product/Index";
        //    return View(products);
        //}
        //public IActionResult Detail()
        //{
        //    ViewData["Title"] = "Product/Details";
        //    return View("explain");
        //}

        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}


        //[HttpPost]
        //public IActionResult Create(Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View(product);

        //}

        //public IActionResult Edit(int id)
        //{
        //    return View();
        //}
    }
}
