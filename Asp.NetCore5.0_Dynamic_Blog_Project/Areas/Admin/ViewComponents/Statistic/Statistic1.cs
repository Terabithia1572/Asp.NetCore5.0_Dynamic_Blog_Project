using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Asp.NetCore5._0_Dynamic_Blog_Project.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1:ViewComponent
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.toplamblogSayisi = blogManager.GetList().Count();
            ViewBag.mesajSayisi = context.Contacts.Count();
            ViewBag.toplamyorumSayisi = context.Comments.Count();
            string api = "b75c2ca9e69997207c923bc5666d536c";
                string connection = "https://api.openweathermap.org/data/2.5/weather?q=van&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            ViewBag.Sicaklik = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;

            return View();
        }
    }
}
