using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Asp.NetCore5._0_Dynamic_Blog_Project.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {
        Message2Manager messageManager = new Message2Manager(new EfMessage2Repository());
        Context c = new Context();

        public IActionResult InBox()
        {
            var userName = User.Identity.Name;
            var userMail = c.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            //sisteme otantike olan kullanıcının bilgilerinin gelmesi
            var writerId = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            var values = messageManager.GetInboxListByWriter(writerId);
            return View(values);
        }

        public IActionResult SendBox()
        {
            var userName = User.Identity.Name;
            var userMail = c.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            //sisteme otantike olan kullanıcının bilgilerinin gelmesi
            var writerId = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            var values = messageManager.GetSendBoxListByWriter(writerId);
            return View();
        }

        
        public IActionResult MessageDetails(int id)
        {
            var value = messageManager.TGetByID(id);

            return View(value);
        }

        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendMessage(Message2 message)
        {
            var userName = User.Identity.Name;
            var userMail = c.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            //sisteme otantike olan kullanıcının bilgilerinin gelmesi
            var writerId = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            message.SenderID = writerId;
            message.ReceiverID = 1;
            message.MessageStatus = true;
            message.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            messageManager.TAdd(message);
            return RedirectToAction("Inbox");
        }
    }
}
