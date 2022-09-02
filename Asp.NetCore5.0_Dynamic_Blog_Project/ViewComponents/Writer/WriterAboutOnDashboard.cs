﻿using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_Dynamic_Blog_Project.ViewComponents.Writer
{
    public class WriterAboutOnDashboard : ViewComponent
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
        public IViewComponentResult Invoke()
        {
            var userMail = User.Identity.Name;
            Context c = new Context();
            //var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(
            //    y => y.WriterID).FirstOrDefault();
            //var values = writerManager.GetWriterByID(writerID);
            return View();
        }

    }

}
