using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_Dynamic_Blog_Project.Controllers
{
    public class WriterController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WriterProfile()
        {
            return View();
        }
    }
}
