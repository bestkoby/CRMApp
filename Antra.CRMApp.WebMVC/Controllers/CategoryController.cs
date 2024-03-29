﻿using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace Antra.CRMApp.WebMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryServiceAsync categoryServiceAsync;
        public CategoryController(ICategoryServiceAsync ser)
        {
            categoryServiceAsync = ser;
        }
        public async Task<IActionResult> Index()
        {
            var result = await categoryServiceAsync.GetAllAsync();
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await categoryServiceAsync.AddCategoryAsync(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.IsEdit = false;
            var empModel = await categoryServiceAsync.GetCategoryForEditAsync(id);
            return View(empModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CategoryRequestModel model)
        {
            ViewBag.IsEdit = false;
            if (ModelState.IsValid)
            {
                await categoryServiceAsync.UpdateCategoryAsync(model);
                ViewBag.IsEdit = true;
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await categoryServiceAsync.DeleteCategoryAsync(id);
            return RedirectToAction("Index");
        }
    }
}
