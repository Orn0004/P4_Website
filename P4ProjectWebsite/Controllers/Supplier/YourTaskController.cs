using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using P4ProjectWebsite.Models.Queries;

namespace P4ProjectWebsite.Controllers.Supplier
{
    public class YourTaskController : Controller
    {
        private readonly IConfiguration _configuration;
        public YourTaskController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var q = new DeleteTask(_configuration); 
            q.RemoveTask(Id);
            return RedirectToAction("YourTasks");
        }
        public IActionResult YourTasks()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var q = new GetOpenTasks(_configuration);
            string username = q.FindUsername(userId);
            var yourList = q.GetYourList(username);
            return View("../Task/Supplier/YourTasks", yourList);
        }
    }
}