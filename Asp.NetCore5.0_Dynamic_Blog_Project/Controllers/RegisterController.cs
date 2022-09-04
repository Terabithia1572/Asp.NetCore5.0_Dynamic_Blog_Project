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

namespace Asp.NetCore5._0_Dynamic_Blog_Project.Controllers
{
    public class RegisterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Writer p)
        {
            WriterValidator _writerValidator = new WriterValidator(); // Fluent Validation Result seçiyoruz
            ValidationResult result = _writerValidator.Validate(p); //sonuc adında bir parametre oluşturduk
            // p den gelen değğerler doğruysa
            if(result.IsValid) //eger ki sonuçlar geçerli ise o zaman süslü parantez içindekileri yap
            {
                p.WriterStatus = true;
                p.WriterAbout = "Deneme Test";
                writerManager.TAdd(p);
                return RedirectToAction("Index", "Blog");
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
