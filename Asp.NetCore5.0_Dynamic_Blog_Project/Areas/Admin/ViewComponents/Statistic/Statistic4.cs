using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_Dynamic_Blog_Project.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4:ViewComponent
    {
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.adminAdi = context.Admins.Where(x => x.AdminID == 1).Select(y => y.Name)
                .FirstOrDefault();
            ViewBag.Image = context.Admins.Where(x => x.AdminID == 1).Select(y => y.ImageURL)
                .FirstOrDefault();
            ViewBag.adminAciklama = context.Admins.Where(x => x.AdminID == 1).Select(y => y.ShortDescription)
                .FirstOrDefault();
            return View();
        }
    }
}
