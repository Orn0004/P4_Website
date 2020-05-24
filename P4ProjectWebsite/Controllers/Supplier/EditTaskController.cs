using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using P4ProjectWebsite.Models.Queries;

namespace P4ProjectWebsite.Controllers.Supplier
{
    public class EditTaskController : Controller
    {
        private readonly IConfiguration _configuration;
        public EditTaskController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Edit(int taskId)
        {
            string Title = HttpContext.Request.Form["Title"];
            string Description = HttpContext.Request.Form["Description"];
            int Duration = int.Parse(HttpContext.Request.Form["Duration"]);
            string Location = HttpContext.Request.Form["Location"];
            string Category = Request.Form["Category"];

            EditTask q = new EditTask(_configuration);

            q.Update(taskId, Title, Description, Duration, Location, Category);

            return RedirectToAction("YourTasks", "YourTask");
        }
    }
}