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
using P4ProjectWebsite.Models.Queries;

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
            var g = new GetCategories(_configuration);
            var CategoryList = g.GetList();
            return View("Supplier/AddTask" , CategoryList);
        }
        public IActionResult Save()
        {
 
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var b = new TaskEntity
            {
                Title = HttpContext.Request.Form["Title"],
                Description = HttpContext.Request.Form["Description"],
                Salary = int.Parse(HttpContext.Request.Form["Salary"]),
                Location = HttpContext.Request.Form["Location"],
                Duration = int.Parse(HttpContext.Request.Form["Duration"]),
                Category = Request.Form["Category"]
            };
            var q = new SaveTask(_configuration);
            //int CategoryId = q.FindCategoryId(Request.Form["Category"]);
            var a = new RelationTaskAddEntity
            {
                Userid = userId,
                //Categoryid = CategoryId
            };
            
            
            q.InsertTask(b);
            q.InsertRelation(a);
            return RedirectToAction("Index");
        }
    }
}