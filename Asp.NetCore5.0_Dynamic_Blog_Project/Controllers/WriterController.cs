using Asp.NetCore5._0_Dynamic_Blog_Project.Models;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_Dynamic_Blog_Project.Controllers
{
    public class WriterController : Controller
    {

        WriterManager writerManager = new WriterManager(new EfWriterRepository());
        UserManager userManager = new UserManager(new EfUserRepository());

        private readonly UserManager<AppUser> _userManager;

        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            var usermail = User.Identity.Name;
            ViewBag.userName = usermail;
            Context context = new Context();
            var writerName = context.Writers.Where(x => x.WriterMail == usermail)
                .Select(y => y.WriterName).FirstOrDefault();
            ViewBag.writerName = writerName;
            return View();
        }
        public IActionResult WriterProfile()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }
        
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }
        [HttpGet]
        public async Task<IActionResult> WriterEditProfile()
        {
            //Context c = new Context();
            //var userName = User.Identity.Name;
            //var userMail = c.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            ////var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(
            ////    y => y.WriterID).FirstOrDefault();
            ////var writervalues = writerManager.TGetByID(writerID);
            ////return View(writervalues);
            ////var values =await _userManager.FindByNameAsync(User.Identity.Name);
            //var id =c.Users.Where(x=>x.Email==userMail).Select(y=>y.Id).FirstOrDefault();
            //var values = userManager.TGetByID(id);



            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel model = new UserUpdateViewModel();
            model.mail = values.Email;
            model.username = values.UserName;
            model.namesurname = values.NameSurname;
            model.imageurl = values.ImageUrl;
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserUpdateViewModel model)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            //model.mail = values.Email;
            //model.username = values.UserName;
            //model.namesurname = values.NameSurname;
            //model.imageurl = values.ImageUrl;
            values.NameSurname = model.namesurname;
            values.UserName = model.username;
            values.ImageUrl = model.imageurl;
            values.Email = model.mail;
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, model.password);
            var result = await _userManager.UpdateAsync(values);
            return RedirectToAction("Index", "Dashboard");
        }
        
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
            Writer w = new Writer();
            if (p.WriterImage != null)
            {
                var extension = Path.GetExtension(p.WriterImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                w.WriterImage = newimagename;
            }
            w.WriterMail = p.WriterMail;
            w.WriterName = p.WriterName;
            w.WriterPassword = p.WriterPassword;
            w.WriterStatus = true;
            w.WriterAbout = p.WriterAbout;
            writerManager.TAdd(w);
            return RedirectToAction("Index", "Dashboard");
        }

    }
}
