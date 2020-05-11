using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using P4ProjectWebsite.Data;
using P4_Data.Entities;

namespace P4ProjectWebsite.Controllers
{
    public class RegisterInfoController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly P4Context _context;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RegisterInfoController(
            P4Context context,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
        }

            public IActionResult Index()
        {
            return View("RegisterInfo");
        }
        
        
        [HttpPost]
        public async Task<IActionResult> UpdateRole(RolesEntityUpdate vm)
        {
            // assigns a variable that finds the user that has that specific email address.
            var user = await _userManager.FindByEmailAsync(vm.UserEmail);

            await _userManager.AddToRoleAsync(user, vm.Role);

            return RedirectToAction("Index");
        }

    }
}