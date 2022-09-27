using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCore5._0_Dynamic_Blog_Project.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {
        Message2Manager messageManager = new Message2Manager(new EfMessage2Repository());

        public IActionResult InBox()
        {
            int id = 2;
            var values = messageManager.GetInboxListByWriter(id);
            return View(values);
        }

        
        public IActionResult MessageDetails(int id)
        {
            var value = messageManager.TGetByID(id);

            return View(value);
        }
    }
}
