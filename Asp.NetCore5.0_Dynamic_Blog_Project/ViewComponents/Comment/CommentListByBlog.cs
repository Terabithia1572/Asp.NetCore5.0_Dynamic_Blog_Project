using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_Dynamic_Blog_Project.ViewComponents.Comment
{
    public class CommentListByBlog:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            CommentManager commentManager = new CommentManager(new EfCommentRepository());
            var values = commentManager.GetList(2);
            return View(values);
        }
    }
}
