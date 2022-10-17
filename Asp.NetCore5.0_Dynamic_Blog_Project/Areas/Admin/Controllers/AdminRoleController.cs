using Asp.NetCore5._0_Dynamic_Blog_Project.Areas.Admin.Models;
using Asp.NetCore5._0_Dynamic_Blog_Project.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_Dynamic_Blog_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminRoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        public AdminRoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel roleViewModel)
        {
            if(ModelState.IsValid)
            {
                AppRole role = new AppRole
                {
                    Name = roleViewModel.name
                };

                var result = await _roleManager.CreateAsync(role);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("",item.Description);
                }
            }
            return View(roleViewModel);
        }
        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            RoleUpdateViewModel roleUpdateViewModel = new RoleUpdateViewModel
            {
                Id = values.Id,
                name = values.Name

            };

            return View(roleUpdateViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRole(RoleUpdateViewModel roleUpdateViewModel)
        {
            var values = _roleManager.Roles.Where(x => x.Id == roleUpdateViewModel.Id).FirstOrDefault();
            values.Name = roleUpdateViewModel.name;
            var result = await _roleManager.UpdateAsync(values);
            if(result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            return View(roleUpdateViewModel);
        }
        public async Task<IActionResult> DeleteRole(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            var result = await _roleManager.DeleteAsync(values);
            if(result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
