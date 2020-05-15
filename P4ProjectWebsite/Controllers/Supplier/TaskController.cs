using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using P4ProjectWebsite.Models;
using P4ProjectWebsite.Models.Queries;
using Microsoft.AspNetCore.Identity;
using System.Security.Principal;
using System.Security.Claims;

namespace P4ProjectWebsite.Controllers.Supplier
{
    [Authorize(Policy = "SupplierAccess")]
    public class TaskController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<IdentityUser> _userManager;
        public TaskController(IConfiguration configuration, UserManager<IdentityUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;

        }


        public IActionResult Index()
        {
            return View("Supplier/AddTask");
        }
        public IActionResult Save()
        {
            //var userId = User.Identity.GetUserId();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var b = new Tasks
            {
                Title = HttpContext.Request.Form["Title"],
                Description = HttpContext.Request.Form["Description"],
                Salary = int.Parse(HttpContext.Request.Form["Salary"]),
                Location = HttpContext.Request.Form["Location"],
                Duration = int.Parse(HttpContext.Request.Form["Duration"])
            };
            var q = new SaveTask(_configuration);

            q.Insert(b);
            return RedirectToAction("Index");
        }
    }
}