using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Edura.WebUI.Repository.Abstract;
using Edura.WebUI.Models;
using Edura.WebUI.Entity;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace Edura.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IUnitOfWork unitofWork;

        public AdminController(IUnitOfWork _unitofWork)
        {
            unitofWork = _unitofWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            var entity = unitofWork.Categories.GetAll()
                                .Include(i => i.ProductCategories)
                                .ThenInclude(i => i.Product)
                                .Where(i => i.CategoryId == id)
                                .Select(i => new AdminEditCategoryModel()
                                {
                                    CategoryId = i.CategoryId,
                                    CategoryName = i.CategoryName,
                                    Products = i.ProductCategories.Select(a => new AdminEditCategoryProduct()
                                    {
                                        ProductId = a.ProductId,
                                        ProductName = a.Product.ProductName,
                                        Image = a.Product.Image,
                                        IsApproved = a.Product.IsApproved,
                                        IsFeatured = a.Product.IsFeatured,
                                        IsHome = a.Product.IsHome
                                    }).ToList()
                                }).FirstOrDefault();

            return View(entity);
        }

        [HttpPost]
        public IActionResult EditCategory(Category entity)
        {
            if (ModelState.IsValid)
            {
                unitofWork.Categories.Edit(entity);
                unitofWork.SaveChanges();

                return RedirectToAction("CatalogList");
            }

            return View("Error");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveFromCategory(int ProductId, int CategoryId)
        {
            if (ModelState.IsValid)
            {
                //silme
                unitofWork.Categories.RemoveFromCategory(ProductId, CategoryId);
                unitofWork.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }


        public IActionResult CatalogList()
        {
            var model = new CatalogListModel()
            {
                Categories = unitofWork.Categories.GetAll().ToList(),
                Products = unitofWork.Products.GetAll().ToList()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCategory(Category entity)
        {
            if (ModelState.IsValid)
            {
                unitofWork.Categories.Add(entity);
                unitofWork.SaveChanges();

                return Ok(entity);
            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddProduct(Product entity, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\products", file.FileName);
                    var path_tn = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\products\\tn", file.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                        entity.Image = file.FileName;
                    }

                    using (var stream = new FileStream(path_tn, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }

                entity.DateAdded = DateTime.Now;
                unitofWork.Products.Add(entity);
                unitofWork.SaveChanges();
                return RedirectToAction("CatalogList");
            }

            return View(entity);
        }
    }
}