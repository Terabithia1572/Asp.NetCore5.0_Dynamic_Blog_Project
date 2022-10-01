using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_Dynamic_Blog_Project.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2:ViewComponent
    {
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
           // ViewBag.toplamblogSayisi = blogManager.GetList().Count();
            ViewBag.sonPost = context.Blogs.OrderByDescending(x=>x.BlogID).Select(x=>x.BlogTitle)
                .Take(1).FirstOrDefault();
            ViewBag.toplamyorumSayisi = context.Comments.Count();
            return View();
        }
    }
}
