using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_Dynamic_Blog_Project.Areas.Admin.Controllers
{
    public class AdminMessageController : Controller
    {
        [Area("Admin")]
        public IActionResult InBox()
        {
            return View();
        }
    }
}
