using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bulky.DataAccess.Data;
using Bulky.Models;
using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.DataAccess.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace repos.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWorkRepository _unitOfWork;

        public ProductController(IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Product> objProductList = _unitOfWork.Product.GetAll().ToList();

            return View(objProductList);
        }

        public IActionResult Create()
        {
            IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll()
            .Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()

            });

            ViewBag.CategoryList = CategoryList; // key value
             
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product obj)
        {
            
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            Product? productFromDb = _unitOfWork.Product.Get(u => u.Id == id);

            if (productFromDb == null)
            {
                return NotFound();
            }

            return View(productFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Product obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product edited successfully";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            Product? productFromDb = _unitOfWork.Product.Get(u => u.Id == id);

            if (productFromDb == null)
            {
                return NotFound();
            }

            return View(productFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int id)
        {

            Product? productFromDb = _unitOfWork.Product.Get(u => u.Id == id);

            if (productFromDb == null)
            {
                return NotFound();
            }

            _unitOfWork.Product.Remove(productFromDb);
            _unitOfWork.Save();
            TempData["success"] = "Product deleted successfully";
            return RedirectToAction("Index");
        }

    }
}
