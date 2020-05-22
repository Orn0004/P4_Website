using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using P4ProjectWebsite.Models;
using P4ProjectWebsite.Data;
using P4_Data.Entities;
using P4ProjectWebsite.Roles;

namespace P4ProjectWebsite.Controllers
{
    //[Authorize(Policy = "AdminAccess")]
    public class RoleController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly P4Context _context;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(
            P4Context context,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
        }

        public IActionResult RoleIndex()
        {
            var roles = _context.Roles.ToList();
            var users = _context.Users.ToList();
            var userRoles = _context.UserRoles.ToList();

            var convertedUsers = users.Select(x => new UsersEntity
            {
                Email = x.Email,
                Roles = roles
                    .Where(y => userRoles.Any(z => z.UserId == x.Id && z.RoleId == y.Id))
                    .Select(y => new UsersRole
                    {
                        Name = y.NormalizedName
                    })
            });

            return View(new DisplayViewModel
            {
                Roles = roles.Select(x => x.NormalizedName),
                Users = convertedUsers
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(string email)
        {
            var user = new IdentityUser
            {
                UserName = email,
                Email = email
            };

            await _userManager.CreateAsync(user, "password");

            return RedirectToAction("RoleIndex");
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(UsersRole vm)
        {
            await _roleManager.CreateAsync(new IdentityRole { Name = vm.Name });

            return RedirectToAction("RoleIndex");
        }


        [HttpPost]
        public async Task<IActionResult> UpdateRole (RolesEntityUpdate vm)
        {
            
            // assigns a variable that finds the user that has that specific email address.
            var user = await _userManager.FindByEmailAsync(vm.UserEmail);

            if (vm.Delete)
                await _userManager.RemoveFromRoleAsync(user, vm.Role);
            else
                await _userManager.AddToRoleAsync(user, vm.Role);

            return RedirectToAction("RoleIndex");
        }
    }
}