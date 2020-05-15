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

namespace P4ProjectWebsite.Controllers.Supplier
{
    [Authorize(Policy = "SupplierAccess")]
    public class TaskController : Controller
    {
        private readonly IConfiguration _configuration;
        public TaskController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View("Supplier/AddTask");
        }
        public IActionResult Save()
        {
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