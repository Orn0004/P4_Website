using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using P4ProjectWebsite.Models;
using P4ProjectWebsite.Models.Queries;

namespace P4ProjectWebsite.Controllers
{
    public class TaskController : Controller
    {
        private readonly IConfiguration _configuration;
        public TaskController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult OpenTasks()
        {
            var q = new GetOpenTasks(_configuration);
            return View(q.GetList());
        }
        public IActionResult SingleTask(int id)
        {

            var q = new GetOpenTasks(_configuration);
            var task = q.GetSingleTask(id);
            
           
            return View(task);
        }

        public IActionResult ArchivedTask(int id)
        {
            var q = new GetOpenTasks(_configuration);
            var task = q.GetArchivedTask(id);
            return View(task);
        }

    }
}