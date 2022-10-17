using Asp.NetCore5._0_Dynamic_Blog_Project.Areas.Admin.Models;
using Asp.NetCore5._0_Dynamic_Blog_Project.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_Dynamic_Blog_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Moderator")]
    public class AdminRoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public AdminRoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
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
        public IActionResult UserRoleList()
        {
            var values =_userManager.Users.ToList();
            return View(values);
        }
        [HttpGet]

        public async Task<IActionResult> AssignRole(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            var roles = _roleManager.Roles.ToList();

            TempData["UserID"] = user.Id;

            var userRoles = await _userManager.GetRolesAsync(user);

            List<RoleAssignViewModel> roleAssignViewModels = new List<RoleAssignViewModel>();
            foreach ( var item in roles)
            {
                RoleAssignViewModel model = new RoleAssignViewModel();
                model.RoleID = item.Id;
                model.Name = item.Name;
                model.Exists = userRoles.Contains(item.Name);
                roleAssignViewModels.Add(model);
            }

            return View(roleAssignViewModels);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> roleAssignViewModels)
        {
            var userID =(int) TempData["UserID"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userID);
            foreach (var item in roleAssignViewModels)
            {
                if(item.Exists)
                {
                   await _userManager.AddToRoleAsync(user, item.Name);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.Name);
                }
            }
            return RedirectToAction("UserRoleList");
        }
    }
}
