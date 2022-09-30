using Asp.NetCore5._0_Dynamic_Blog_Project.Areas.Admin.Models;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_Dynamic_Blog_Project.Areas.Admin.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult ExportStaticBlogList()
        {
            using (var workbook=new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "Blog ID";
                worksheet.Cell(1, 2).Value = "Blog Adı";

                int BlogRowCount = 2;
                foreach (var item in GetBlogList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value=item.ID;
                    worksheet.Cell(BlogRowCount, 2).Value=item.blogName;
                    BlogRowCount++;
                }
                using(var stream=new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }
            }
            
        }
        public List<BlogModel> GetBlogList()
        {
            List<BlogModel> blogModels = new List<BlogModel>
            {
                new BlogModel {ID=1,blogName="C# Programlamaya Giriş"},
                new BlogModel {ID=2,blogName="Tesla Firmanın Araçları"},
                new BlogModel {ID=3,blogName="Galatasaray'ın UEFA Macerası"}
            };
            return blogModels;
        }
    }
}
