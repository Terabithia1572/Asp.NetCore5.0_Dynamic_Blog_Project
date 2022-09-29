using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Asp.NetCore5._0_Dynamic_Blog_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index(int page=1)
        {
            var values = categoryManager.GetList().ToPagedList(page,3);
            return View(values);
        }
        [HttpGet]

        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            CategoryValidator _categoryValidator = new CategoryValidator(); // Fluent Validation Result seçiyoruz
            ValidationResult result = _categoryValidator.Validate(category); //sonuc adında bir parametre oluşturduk


            // p den gelen değğerler doğruysa
            if (result.IsValid) //eger ki sonuçlar geçerli ise o zaman süslü parantez içindekileri yap
            {
                category.CategoryStatus = true;
                
                
                categoryManager.TAdd(category);
                return RedirectToAction("Index", "Category");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
