using Asp.NetCore5._0_Dynamic_Blog_Project.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_Dynamic_Blog_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WriterList()
        {
            var jsonWriters = JsonConvert.SerializeObject(writers);
            return Json(jsonWriters);
        }

        public IActionResult GetWriterByID(int WriterID)
        {
            var findWriter = writers.FirstOrDefault(x => x.ID == WriterID);
            var jsonWriters = JsonConvert.SerializeObject(findWriter);
            return Json(jsonWriters);
        }

        public IActionResult AddWriter(WriterClass writer)
        {
            writers.Add(writer);
            var jsonWriters = JsonConvert.SerializeObject(writer);
            return Json(jsonWriters);
        }

        public IActionResult DeleteWriter(int id)
        {
            var writer = writers.FirstOrDefault(x => x.ID == id);
            writers.Remove(writer);
            return Json(writer);
        }

        public IActionResult UpdateWriter(WriterClass w)
        {
            var writer = writers.FirstOrDefault(x => x.ID == w.ID);
            writer.Name = w.Name;
            var jsonWriter = JsonConvert.SerializeObject(w);
            return Json(jsonWriter);
        }

        public static List<WriterClass> writers = new List<WriterClass>
        {
            new WriterClass
            {
                ID=1,
                Name="Ayşe"
            },
            new WriterClass
            {
                ID=2,
                Name="Ahmet"
            },
            new WriterClass
            {
                ID=3,
                Name="Buse"
            }

        };
    }
}
