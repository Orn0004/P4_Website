using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using P4ProjectWebsite.Models;
using P4ProjectWebsite.Models.Queries;

namespace P4ProjectWebsite.Controllers.Admin
{
    [Authorize(Policy = "AdminAccess")]
    public class CategoryController : Controller
    {
        private readonly IConfiguration _configuration;
        public CategoryController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View("../Category/AddCategory");
        }

        public IActionResult ShowCategories()
        {
            var q = new GetCategories(_configuration);
            return View(q.GetList());
        }
        [HttpGet]
        public IActionResult Delete(string name)
        {
            var q = new DeleteCategory(_configuration);

            q.RemoveCategory(name);
            return RedirectToAction("ShowCategories");
        }
        public IActionResult Save()
        {
            var b = new CategoryEntity
            {
                Name = HttpContext.Request.Form["Name"],
                Type = HttpContext.Request.Form["Type"],
            };
            var q = new AddCategory(_configuration);

            q.InsertCategory(b);
            return RedirectToAction("Index");
        }
    }
}
