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
            return View(q.GetSingleTask(id));
        }
        public IActionResult SendBid(int taskId, int currentBid)
        {
            int bid = int.Parse(HttpContext.Request.Form["Bid"]);
            if (bid < currentBid)
            {
                string ContributorId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var q = new AddBid(_configuration);
                string SupId = q.FindSupId(taskId);
                var b = new BidEntity
                {

                    Bid = bid,
                    ContributorId = ContributorId,
                    SupplierId = SupId,
                    TaskId = taskId,
                    Confirmation = 0

                };

                q.InsertBid(b);
                q.InsertBidIntoTask(bid, taskId);
            }

            return RedirectToAction("OpenTasks");
        }
    }
}