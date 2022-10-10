using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_Dynamic_Blog_Project.Controllers
{
    public class DashboardController : Controller
    {

        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        Context c = new Context();

        
        public IActionResult Index()
        {
            var userName = User.Identity.Name;
            var userMail = c.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();

            ViewBag.ToplamBlogSayisi = blogManager.GetList().Count();
            ViewBag.YazarinBlogSayisi = blogManager.GetBlogListByWriter(writerID).Count();
            ViewBag.KategoriSayisi = categoryManager.GetList().Count();
            return View();
        }
    }
}
