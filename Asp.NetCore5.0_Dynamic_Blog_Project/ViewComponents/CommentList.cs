using Asp.NetCore5._0_Dynamic_Blog_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_Dynamic_Blog_Project.ViewComponents
{
    public class CommentList:ViewComponent
    {
        //Invoke Çağır demek
        public IViewComponentResult Invoke()
        {
            var commentvalues = new List<UserComment>
            {
                new UserComment
                {
                    ID=1,
                    UserName="Yunus İNAN"

                },
                new UserComment
                {
                    ID=2,
                    UserName="Faruk Erdemiş"
                }
            };
            return View(commentvalues);
        }
    }
}
