﻿using BlogApiDemo.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApiDemo.Controllers
{

    
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public IActionResult EmployeeList()
        {
            using var context = new Context();
            var values = context.Employees.ToList();
            return Ok(values); // api başarılı istek olursa parantez içinde dönecek status kodu yazılıyor.
        }

        [HttpPost]

        public IActionResult EmployeeAdd(Employee employee)
        {
            using var context= new Context();
            context.Add(employee);
            context.SaveChanges();
            return Ok();
        }
    }
}
