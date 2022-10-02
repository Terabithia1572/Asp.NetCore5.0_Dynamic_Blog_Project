using Asp.NetCore5._0_Dynamic_Blog_Project.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_Dynamic_Blog_Project.Areas.Admin.Controllers
{
    public class ChartController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryChart()
        {
            List<CategoryClass> List = new List<CategoryClass>();
            List.Add(new CategoryClass
            {
                CategoryName = "Teknoloji",
                CategoryCount = 10
            });
            List.Add(new CategoryClass
            {
                CategoryName = "Yazılım",
                CategoryCount = 14
            });
            List.Add(new CategoryClass
            {
                CategoryName = "Spor",
                CategoryCount = 5
            });
            return Json(new { jasonList = List });
        }
    }
}
